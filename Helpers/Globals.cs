using BepInEx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypnoReplacer.Helpers
{
    internal static class Globals
    { 

        internal static string defaultSpriteFolderPath = Path.Combine(Paths.PluginPath, "Sprites");
        internal static string defaultSpriteDataPath = Path.Combine(Paths.PluginPath, "SpriteData");
        internal static int texture2dWidth = 1440;
        internal static int texture2dHeight = 1440;

    }
}
