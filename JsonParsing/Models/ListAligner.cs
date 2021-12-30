using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParsing.Models
{
    internal class StringListAligner
    {
        public string ReturnChildrenWithSingleLine(List<string> list)
        {
            string result = String.Empty;
            StringBuilder sb = new StringBuilder();
            sb.Append("Children: \"");
            for (int i = 0; i < list.Count; i++)
            {
                sb.Append(String.Format("<{0}>,", list[i]));
            }
            return sb.ToString().TrimEnd(',') + "\"";
        }

        public string ReturnNodeNameString(string nodeName)
        {
            return !String.IsNullOrWhiteSpace(nodeName) ? String.Format("Node-name: \"<{0}>\"", nodeName) : "Node-name:";
        }

        public string ReturnParentNameString(string parent)
        {
            return !String.IsNullOrWhiteSpace(parent) ? String.Format("Parent-node-name: \"<{0}>\"", parent) : "Parent-node-name:";
        }
    }
}
