using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Configuration;

namespace AppConfigEnv {
  public class ConfigFile {
    public static ConfigFile Load(string path, string section) {
      var doc = new XmlDocument();
      doc.Load(path);
      XmlNode node = null;
      if (string.IsNullOrEmpty(section)) {
        node = doc.DocumentElement;
      } else {
        node = doc.DocumentElement.SelectSingleNode(string.Format("//{0}", section));
      }
      var x = node.SelectSingleNode(string.Format("//{0}", CurrentEnvironment));
      return new ConfigFile(x);
    }

    private XmlNode nodeConfig;
    private ConfigFile(XmlNode node) {
      nodeConfig = node;
    }

    public string this[string key] {
      get {
        return nodeConfig.SelectSingleNode(string.Format("{0}", key)).InnerText;
      }
    }

    private static string CurrentEnvironment {
      get {
        var env = "development";
        try {
          env = Environment.GetEnvironmentVariable("APP_ENV") ?? "development";
        } catch {
        }
        if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["AppEnv"])) {
          env = ConfigurationManager.AppSettings["AppEnv"];
        }
        return env;
      }
    }
  }
}
