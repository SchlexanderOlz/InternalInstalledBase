namespace DapperExtension.Config;

using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;


public class ConfigParser {

  public static string GetConnectionData(string path)
  {
    var yaml = new DeserializerBuilder()
        .WithNamingConvention(CamelCaseNamingConvention.Instance)
        .Build();

    Dictionary<string, string> dbConfig = yaml.Deserialize<Dictionary<string, string>>(File.ReadAllText(path));

    string server = dbConfig["server"];
    string port = dbConfig["port"];
    string database = dbConfig["database"];
    string user = dbConfig["user"];
    string password = dbConfig["password"];

    return $"server={server};port={port};database={database};user={user};password={password}";
  }
}
