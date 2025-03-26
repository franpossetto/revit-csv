using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using Services;
using Services.Exporter;

namespace RevitCSV
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]

    public class ExternalCommand : IExternalCommand
    {
        /// <summary>
        ///     External Command
        /// </summary>
        /// <param name ="commandData"></param>
        /// <param name="message"></param>
        /// <param name="elements"></param>
        /// <returns></returns>

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                //Check Revit Version
                if (!commandData.Application.Application.VersionName.Contains("2023"))
                {
                    using (TaskDialog taskDialog = new TaskDialog("Cannot Continue"))
                    {
                        taskDialog.TitleAutoPrefix = false;
                        taskDialog.MainInstruction = "Incompatible Version of Revit";
                        taskDialog.MainContent = "Main Content";
                        taskDialog.Show();
                    }
                    return Result.Cancelled;
                }

                var doc = commandData.Application.ActiveUIDocument.Document;

                IElementCollector collector = new MatrixElementCollector(doc);
                List<Element> allElements = collector.FetchElements();

                var exporter = new CsvExporter();
                var exportService = new ElementExporterService(exporter);

                var collection = exportService.TransformElementsToObjects(allElements);
                // for all objects in collection, add a key "RevitVersion" with the current version
                foreach (var obj in collection)
                {
                    obj["RevitVersion"] = commandData.Application.Application.VersionName;
                }


                exportService.ExportMatrixInfoV3(collection, doc.Title);

                TaskDialog.Show("Export", "Export completed");
                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Result.Failed;
            }
        }
    }
}
