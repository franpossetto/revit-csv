using Autodesk.Revit.DB;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class MatrixElementCollector : IElementCollector
    {
        private readonly Document _doc;

        public MatrixElementCollector(Document doc)
        {
            _doc = doc;
        }

        public List<Element> FetchElements()
        {
            var instances = new FilteredElementCollector(_doc)
                .WhereElementIsNotElementType()
                .ToElements().ToList();

            return instances;
        }
    }
}
