using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParsing.Models
{
    internal class JsonNode
    {
        public string NodeName { get; set; }
        public List<JsonNode> Children { get; set; }
    }

    internal class ResultSet
    {
        //!!!!!!!!!!!! ИСПОЛЬЗОВАНИЕ КОНСТРУКТОРА ВОЗВРАЩАЕТ ПУСТОЕ CHILDREN !!!!!!!!!!!!!!!

        //public ResultSet(string node, string parent, int depth)
        //{
        //    NodeName = node;
        //    Parent = parent;
        //    Depth = Depth;
        //    Children = new();
        //}

        public string NodeName { get; set; }
        public string Parent { get; set; }
        public int Depth { get; set; }
        public List<string> Children { get; set; }

    }

    
}
