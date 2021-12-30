// See https://aka.ms/new-console-template for more information
using JsonParsing.Models;

string path = $@"..\..\..\TechTask1.json";
JsonPrinter printer = new();
JsonFileReader reader = new();
List<ResultSet> result = reader.ReturnDataSet(path);
FileWriter writer = new();
writer.WriteJsonToFile(result);
printer.Print(result);


