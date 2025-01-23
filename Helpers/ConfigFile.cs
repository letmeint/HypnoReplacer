using BepInEx;
using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypnoReplacer.Helpers
{

    internal static class ConfigFile
    {
         
        internal static ConfigEntry<bool> enabled;
        //internal static ConfigEntry<bool> replaceCurrentVRImages;
        internal static ConfigEntry<string> spriteFolderPath;
        internal static ConfigEntry<string> spriteDataPath;

        internal static void Init(BepInEx.Configuration.ConfigFile config)
        {
            enabled = config.Bind("General", "Enabled", true, "Enable the plugin");
            spriteFolderPath = config.Bind<string>("General", "SpriteFolderPath", Globals.defaultSpriteFolderPath, "Path to the folder containing the sprites");
            spriteDataPath = config.Bind<string>("General", "SpriteDataPath", Globals.defaultSpriteDataPath, "Path to the folder containing the sprite data");
            //replaceCurrentVRImages = config.Bind("General", "ReplaceCurrentVRImages", true, "Replace the current VR images with the new ones or add to the original list");
        }
    }
}
