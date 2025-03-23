using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Services.Exporter
{
    public class CsvExporter : IExporter
    {
        public void Export(List<string> headers, List<List<string>> rows, string path)
        {
            var sb = new StringBuilder();

            sb.AppendLine(string.Join(",", headers));

            foreach (var row in rows)
            {
                var sanitized = row.Select(value => value?.Replace(",", " ") ?? "");
                sb.AppendLine(string.Join(",", sanitized));
            }

            File.WriteAllText(path, sb.ToString());
        }
    }
}
