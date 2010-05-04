using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Xml;

namespace AppConfigEnv {
    public class DatabaseElement {
        private XmlDocument doc;

        public DatabaseElement(DefaultSection section) {
            doc = new XmlDocument();
            doc.LoadXml(section.SectionInformation.GetRawXml());
        }

        public string Host {
            get {
                return doc.DocumentElement.SelectSingleNode("//host").InnerText;
            }
        }

        public string Get(string key) {
            var node = doc.DocumentElement.SelectSingleNode(key);
            if (node != null) {
                return node.InnerText;
            } else {
                return null;
            }
        }
    }
}
