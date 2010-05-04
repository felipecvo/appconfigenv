namespace AppConfigEnv {
    using System;
    using System.Configuration;

    //public class EnvironmentSection : ConfigurationSectionGroup {
    public class EnvironmentSection : ConfigurationSectionGroup {

        public EnvironmentSection() {
        }

        public ConfigurationElement Current {
            get {
                // verificar arquivo externo
                // posso usar this.Sections[0].SectionInformation.GetRawXml();
                return this.Sections[CurrentEnvironment] as ConfigurationElement;
            }
        }

        //[ConfigurationProperty("administrator", IsRequired = true)]
        //public string ConfigSource {
        //    get {
        //        return this.SectionGroups["administrator"];
        //    }
        //    set {
        //        this["administrator"] = value;
        //    }
        //}

        private string CurrentEnvironment {
            get {
                return Environment.GetEnvironmentVariable("APP_ENV") ?? "development";
            }
        }
    }

    public class EnvironmentSection2 : ConfigurationSection {
    }
}
