using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Services.Exporter
{
    public class CsvExporter : IExporter
    {
        public void Export(TabularData data, string path)
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Join(",", data.Headers));

            foreach (var row in data.Rows)
            {
                var sanitized = row.Select(v => v?.Replace(",", " ") ?? "");
                sb.AppendLine(string.Join(",", sanitized));
            }

            File.WriteAllText(path, sb.ToString());
        }
    }
}
