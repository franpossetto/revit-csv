using Autodesk.Revit.DB;
using Services.Exporter;
using System;
using System.Collections.Generic;
using System.IO;

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
            var headers = new List<string> { "ElementId", "Category", "Name" };
            var rows = new List<List<string>>();

            foreach (var element in elements)
            {
                rows.Add(new List<string>
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

            _exporter.Export(headers, rows, path);
        }
    }
}
