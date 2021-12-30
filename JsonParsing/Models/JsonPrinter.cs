using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParsing.Models
{
    internal class JsonPrinter
    {
        public void Print(List<ResultSet> lines)
        {
            StringListAligner aligner = new();
            for (int i = 0; i < lines.Count; i++)
            {
                Console.WriteLine(aligner.ReturnNodeNameString(lines[i].NodeName));
                Console.WriteLine(aligner.ReturnParentNameString(lines[i].Parent));
                Console.WriteLine(aligner.ReturnChildrenWithSingleLine(lines[i].Children));
            }
        }
    }
}
