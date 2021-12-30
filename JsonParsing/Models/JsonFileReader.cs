using Newtonsoft.Json;

namespace JsonParsing.Models
{
    internal class JsonFileReader
    {
        List<ResultSet> lines = new();
        string parent = String.Empty;
        string currentNodeName = String.Empty;
        int currentDepth = 0;
        bool IsNodeNameExpected = false;

        public List<ResultSet> ReturnDataSet(string path)
        {
            StringListAligner listAligner = new();

            using (StreamReader sr = new StreamReader(path))
            {
                using (JsonTextReader reader = new JsonTextReader(sr))
                {
                    reader.MaxDepth = 100500;
                    var serializer = new JsonSerializer();
                    
                    while (reader.Read())
                    {
                        if (reader.Value != null)
                        {
                            if (IsNodeNameExpected)
                            {
                                SetParamsBeforeAddItem((string)reader.Value, reader.Depth);
                                AddNewItem(currentNodeName, parent, reader.Depth);
                            }
                            else
                            {
                                SetParamsAfterHadledNodeName(reader.TokenType.ToString(), (string)reader.Value, reader.Depth);
                            }
                            
                        }
                    }
                }
            }
            return lines;
        }

        private void SetParamsBeforeAddItem(string nodeName, int depth)
        {
            IsNodeNameExpected = false;
            currentNodeName = nodeName;
            currentDepth = depth;
        }

        private void SetParamsAfterHadledNodeName(string tokenType, string value, int depth)
        {
            if (depth == currentDepth + 2)
            {
                parent = currentNodeName;
            }
            else
            {
                if (depth != currentDepth)
                {
                    parent = String.Empty;
                }
            }
            if (tokenType == JsonToken.PropertyName.ToString())
            {
                if (value == "NodeName")
                {
                    IsNodeNameExpected = true;
                }

            }
        }

        private void AddNewItem(string curNodeName, string parentNode, int depth)
        {
            //если создать через конструктор, то пустые Children
            ResultSet resultItem = new ResultSet()
            {
                NodeName = curNodeName,
                Parent = parentNode,
                Depth = depth,
                Children = new()
            };
            lines.Add(resultItem);
            lines = lines.Select(i =>
            {
                if (i.Depth == depth - 2 & i.NodeName == parentNode)
                {
                    i.Children.Add(currentNodeName);
                }
                return i;
            }).ToList();
        }
    }
}
