using Autodesk.Revit.DB;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class ElementCollectorService
    {
        private readonly Document _doc;

        public ElementCollectorService(Document doc)
        {
            _doc = doc;
        }

        public List<Element> GetAllElements()
        {
            var instances = new FilteredElementCollector(_doc)
                .WhereElementIsNotElementType()
                .ToElements();

            var types = new FilteredElementCollector(_doc)
                .WhereElementIsElementType()
                .ToElements();

            return instances.Concat(types).ToList();
        }
    }
}
