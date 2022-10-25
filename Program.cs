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

      // Try to get some value and convert to json string.
      Console.WriteLine(JsonSerializer.Serialize(dataHandler.GetDataList("user_count")));

      // The following methods all seem to do the same thing. But you can go to the function definition.
      // 下面的方法看起來都做一樣的事情，但你可以看一下這個方法的定義
      Console.WriteLine(JsonSerializer.Serialize(dataHandler.GetAllDataAvg()));
      Console.WriteLine(JsonSerializer.Serialize(dataHandler.GetAllDataAvgDictionary()));
    }
  }
}