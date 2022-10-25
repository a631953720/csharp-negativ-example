using Service;
using System.Text.Json;
// 解決debuger無法使用的問題
// https://stackoverflow.com/questions/62558818/unable-to-generate-assets-to-build-and-debug-omnisharp-server-is-not-running

namespace HelloWorld
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.OutputEncoding = System.Text.Encoding.UTF8;

      DataHandler dataHandler = new DataHandler();

      Console.WriteLine("Hello World!");
      Console.WriteLine(JsonSerializer.Serialize(dataHandler.GetDataList("user_count")));
      Console.WriteLine(JsonSerializer.Serialize(dataHandler.GetAllDataAvg()));
      Console.WriteLine(JsonSerializer.Serialize(dataHandler.GetAllDataAvgDictionary()));
    }
  }
}