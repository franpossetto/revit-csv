using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Services.Exporter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Xml.Linq;

namespace Services
{
    public class ElementExporterService
    {
        private readonly IExporter _exporter;

        public ElementExporterService(IExporter exporter)
        {
            _exporter = exporter;
        }

        public void ExportBasicInfo(List<Element> elements, string documentTitle)
        {
            var data = new TabularData
            {
                Headers = new List<string> { "ElementId", "Category", "Name" },
                Rows = new List<List<string>>()
            };

            foreach (var element in elements)
            {
                data.Rows.Add(new List<string>
                {
                    element.Id.IntegerValue.ToString(),
                    element.Category?.Name ?? "",
                    element.Name ?? ""
                });
            }

            var folder = Path.Combine("C:\\revit-csv", documentTitle);
            Directory.CreateDirectory(folder);
            var fileName = $"export_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
            var path = Path.Combine(folder, fileName);

            _exporter.Export(data, path);
        }

        public void ExportMatrixInfo(List<Element> elements, string documentTitle)
        {
            var headerSet = new HashSet<string> { "ElementId", "Category", "Name" };
            var rows = new List<List<string>>();

            foreach (var element in elements)
            {
                foreach (Parameter param in element.Parameters)
                {
                    if (param.Definition is InternalDefinition def &&
                        def.BuiltInParameter != BuiltInParameter.INVALID)
                    {
                        headerSet.Add(def.Name);
                    }
                }
            }

            var headers = headerSet.ToList();

            foreach (var element in elements)
            {
                var row = new List<string>();

                foreach (var header in headers)
                {
                    switch (header)
                    {
                        case "ElementId":
                            row.Add(element.Id.IntegerValue.ToString());
                            break;
                        case "Category":
                            row.Add(element.Category?.Name ?? "");
                            break;
                        case "Name":
                            row.Add(element.Name ?? "");
                            break;
                        default:
                            Parameter param = element.LookupParameter(header);
                            row.Add(param?.AsValueString() ?? "");
                            break;
                    }
                }

                rows.Add(row);
            }

            var data = new TabularData
            {
                Headers = headers,
                Rows = rows
            };

            var folder = Path.Combine("C:\\revit-csv", documentTitle);
            Directory.CreateDirectory(folder);
            var fileName = $"matrix_export_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
            var path = Path.Combine(folder, fileName);

            _exporter.Export(data, path);
        }

        public List<Dictionary<String, String>> TransformElementsToObjects(List<Element> elements)
        {
            var collection = new List<Dictionary<String, String>>();

            foreach (var element in elements)
            {
                var obj = new Dictionary<String, String>();

                obj["ElementId"] = element.Id.IntegerValue.ToString();
                obj["Category"] = element.Category?.Name ?? "";
                obj["Name"] = element.Name ?? "";


                foreach (Parameter param in element.Parameters)
                {
                    if (param.Definition is InternalDefinition def &&
                        def.BuiltInParameter != BuiltInParameter.INVALID)
                    {
                        var paramName = def.Name;
                        obj[paramName] = param.AsValueString() ?? "";
                    }
                }

                collection.Add(obj);
            }

            return collection;
        }


        public void ExportMatrixInfoV3(List<Dictionary<String, String>> collection, string documentTitle)
        {
            // headers are the unique keys from all the objects
            var headers = new List<string>();
            foreach (var obj in collection)
            {
                foreach (var key in obj.Keys)
                {
                    if (!headers.Contains(key))
                    {
                        headers.Add(key);
                    }
                }
            }

            var rows = new List<List<string>>();
            foreach (var obj in collection)
            {
                var row = new List<string>();
                foreach (var header in headers)
                {
                    if (obj.ContainsKey(header))
                    {
                        row.Add(obj[header]);
                    }
                    else
                    {
                        row.Add("");
                    }
                }
                rows.Add(row);
            }

            var data = new TabularData
            {
                Headers = headers,
                Rows = rows
            };

            var folder = Path.Combine("C:\\revit-csv", documentTitle);
            Directory.CreateDirectory(folder);
            var fileName = $"matrix_export_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
            var path = Path.Combine(folder, fileName);

            _exporter.Export(data, path);
        }

        public void ExportMatrixInfoV2(List<Element> elements, string documentTitle)
        {
            var headers = new List<string> { "ElementId", "Category", "Name" };
            var headerIndex = new Dictionary<string, int>
    {
        { "ElementId", 0 },
        { "Category", 1 },
        { "Name", 2 }
    };

            var rows = new List<List<string>>();

            foreach (var element in elements)
            {
                var row = new List<string> {
            element.Id.IntegerValue.ToString(),
            element.Category?.Name ?? "",
            element.Name ?? ""
        };

                foreach (Parameter param in element.Parameters)
                {
                    if (param.Definition is InternalDefinition def &&
                        def.BuiltInParameter != BuiltInParameter.INVALID)
                    {
                        var paramName = def.Name;

                        if (!headerIndex.ContainsKey(paramName))
                        {
                            headerIndex[paramName] = headers.Count;
                            headers.Add(paramName);
                            foreach (var existingRow in rows)
                                existingRow.Add("");
                        }

                        while (row.Count <= headerIndex[paramName])
                            row.Add("");

                        row[headerIndex[paramName]] = param.AsValueString() ?? "";
                    }
                }

                rows.Add(row);
            }

            var data = new TabularData
            {
                Headers = headers,
                Rows = rows
            };

            var folder = Path.Combine("C:\\revit-csv", documentTitle);
            Directory.CreateDirectory(folder);
            var fileName = $"matrix_export_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
            var path = Path.Combine(folder, fileName);

            _exporter.Export(data, path);

        }


    }
}
