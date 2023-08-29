/**
 * @file
 * @brief This file contains the defintion of the ParseConfig class
 * @author Alexander Scholz
 * @date 29-08-2023
 */
namespace DapperExtension.Config;

using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;


public class ConfigParser {

  /**
   * @brief Parses the dbconfig file into a MySQL connection-string
   * @param path Filepath of the dbConfig file
   * @return MySQL friendly connection-string
   */
  public static string GetConnectionData(string path)
  {
    // Creates the Yaml-Parser
    var yaml = new DeserializerBuilder()
        .WithNamingConvention(CamelCaseNamingConvention.Instance)
        .Build();

    // Deserialize the specified contents at *path* into a dictionary os strings
    Dictionary<string, string> dbConfig = yaml.Deserialize<Dictionary<string, string>>(File.ReadAllText(path));

    string server = dbConfig["server"];
    string port = dbConfig["port"];
    string database = dbConfig["database"];
    string user = dbConfig["user"];
    string password = dbConfig["password"];

    // Build the connection-string for the MySQl connection
    return $"server={server};port={port};database={database};user={user};password={password}";
  }
}

