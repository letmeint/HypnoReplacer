using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using HypnoReplacer.Data;
using HypnoReplacer.Helpers;

namespace HypnoReplacer
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        internal static new ManualLogSource Logger;

        private void Awake()
        {
            var harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
            harmony.PatchAll();

            Logger = base.Logger;
            Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_NAME} is loaded!");
            
            Init();
        }

        private void Init()
        {
            ConfigFile.Init(Config);
            IOHelper.CreateFolders();
            SpriteDataHelper.CreateSpriteData();

        }
    }
}
