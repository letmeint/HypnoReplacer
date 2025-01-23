using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HypnoReplacer.Helpers
{
    internal static class IOHelper
    {
        internal static void CreateFolders()
        {
            if (!Directory.Exists(ConfigFile.spriteDataPath.Value))
            {
                Directory.CreateDirectory(ConfigFile.spriteDataPath.Value);
            }

            if (!Directory.Exists(ConfigFile.spriteFolderPath.Value))
            {
                Directory.CreateDirectory(ConfigFile.spriteFolderPath.Value);
            }
        }

        internal static T ReadJson<T>(string json)
        {
            using (StreamReader sr = new StreamReader(json))
            {
                string jsonText = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(jsonText);
            }
        }

    }
}
