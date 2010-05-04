using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.ServiceModel.Configuration;

namespace AppConfigEnv.Console {
  class Program {
    static void Main(string[] args) {
      var env = Environment.GetEnvironmentVariable("APP_ENV") ?? "development";
      System.Console.WriteLine(env);

      var db = ConfigFile.Load("database.config", null);
      System.Console.WriteLine(db["host"]);
      System.Console.ReadLine();
      return;
      //var x = ConfigurationManager.GetSection("database");
      //System.Console.WriteLine(x == null);

      var appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
      var y = appConfig.GetSectionGroup("database") as AppConfigEnv.EnvironmentSection;
      var t = y.Current as DefaultSection;
      var e = new DatabaseElement(t);
      System.Console.WriteLine(e.Host);
      System.Console.WriteLine(e.Get("new_database"));

      System.Console.ReadLine();
    }
  }
}
