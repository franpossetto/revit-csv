using System.Collections.Generic;

namespace Services.Exporter
{
    public interface IExporter
    {   
        void Export(TabularData data, string path);
    }
}
