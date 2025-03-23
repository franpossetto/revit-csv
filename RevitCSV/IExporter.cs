using System.Collections.Generic;

namespace Services.Exporter
{
    public interface IExporter
    {
        void Export(List<string> headers, List<List<string>> rows, string path);
    }
}
