using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParsing.Models
{
    internal class FileWriter
    {
        private static string Path = $@"..\..\..\TxtWithFormattedData.txt";
        public void WriteJsonToFile(List<ResultSet> list)
        {
            StringListAligner aligner = new();

            List<string> lines = new();
            for(int i =0; i< list.Count; i++)
            {
                lines.Add(aligner.ReturnNodeNameString(list[i].NodeName));
                lines.Add(aligner.ReturnParentNameString(list[i].Parent));
                lines.Add(aligner.ReturnChildrenWithSingleLine(list[i].Children));
            }
            File.WriteAllLines(Path,lines.ToArray());
        }
    }
}
