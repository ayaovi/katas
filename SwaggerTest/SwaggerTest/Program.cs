using System.IO;
using Newtonsoft.Json.Linq;

namespace SwaggerTest
{
  internal class Program
  {
    static void Main(string[] args)
    {
      const string swaggerFile = @"C:\Users\AyaoviD\Documents\test-standard.json";
      var swagger = JObject.Parse(File.ReadAllText(swaggerFile));
      var definitions = swagger["definitions"].ToString();
      swagger["definitions"].Parent.Remove();
      swagger["info"].Parent.AddAfterSelf(new JProperty("definitions", JToken.Parse(definitions)));
      foreach (var token in swagger["definitions"])
      {
        var jToken = token.First["$id"].ToString();
        token.First["$id"].Parent.Remove();
        var obj = token.First.First.First;
        obj.Parent.AddBeforeSelf(new JProperty("$id", jToken));
      }
      var s = swagger.ToString();
    }
  }
}