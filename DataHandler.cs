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

    /// <summary>
    /// Get data average via hardcoded every data key to get object value!
    /// 
    /// So this function can not get other unknown key values and calculate the average.
    /// 
    /// 透過寫死的方式來取得物件值，且無法取得其他未知的資料值並計算
    /// </summary>
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
      // mock data can not hardcode to get the random key's value!!

      return dataTemplate;
    }

    /// <summary>
    /// Use the foreach to iterate the data and alculate the average.
    /// 
    /// When the data have any new data key, this function can get the new value very well.
    /// 
    /// 透過迴圈迭帶物件結構取值並計算，即便有未知的值也可以正常運作
    /// </summary>
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