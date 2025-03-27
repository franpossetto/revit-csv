using Autodesk.Revit.DB;
using System.Collections.Generic;

namespace Services
{
    public interface IElementCollector
    {
        List<Element> FetchElements();
    }
}
