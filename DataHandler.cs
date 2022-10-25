using System.Linq;

namespace Service
{
  public class DataTemplate 
  {
    public double? movie_count { get; set; }
    public double? user_count { get; set; }
  }
  public class DataHandler
  {
    // 模擬 MongoDB 接過來的資料，為Key value形式，但不知道有多少對!
    private Dictionary<string, List<double>> mockData;

    private static List<double> GenerateMockDataList(string key)
    {
      var data = new List<double>();
      Random rd = new Random();
      for (int i = 0; i < 10; i++)
      {
        double v = rd.Next(100, 200);
        // Console.WriteLine($"key: '{key}' value: {v}");
        data.Add(v);
      }
      return data;
    }

    public DataHandler()
    {
      mockData = new Dictionary<string, List<double>>();

      // mock data
      mockData.Add("movie_count", DataHandler.GenerateMockDataList("movie_count"));
      mockData.Add("user_count", DataHandler.GenerateMockDataList("user_count"));

      // random key
      Random rd = new Random();
      string key = rd.Next(0,100).ToString();
      mockData.Add($"randonKey-{key}", DataHandler.GenerateMockDataList($"randonKey-{key}"));
    }

    public List<double> GetDataList(string key)
    {
      mockData.TryGetValue(key, out List<double>? value);
      if (value == null)
      {
        return new List<double>();
      }
      return value;
    }

    public DataTemplate GetAllDataAvg()
    {
      DataTemplate dataTemplate = new DataTemplate ()
      {
        movie_count = null,
        user_count = null
      };

      mockData.TryGetValue("movie_count", out List<double>? movieCount);
      if (movieCount != null)
      {
        dataTemplate.movie_count = movieCount.Sum() / movieCount.Count;
      }

      mockData.TryGetValue("user_count", out List<double>? user_count);
      if (user_count != null)
      {
        dataTemplate.user_count = user_count.Sum() / user_count.Count;
      }

      // mock data的隨機字串所對應的List就無法取得!!

      return dataTemplate;
    }

    public Dictionary<string, double> GetAllDataAvgDictionary()
    {
      Dictionary<string, double> data = new Dictionary<string, double>();

      foreach (var item in mockData)
      {
        mockData.TryGetValue(item.Key, out List<double>? value);
        if (value != null)
        {
          data.Add(item.Key, value.Sum() / value.Count);
        }
      }

      return data;
    }
  }
}