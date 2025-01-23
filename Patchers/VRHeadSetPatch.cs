using BepInEx.Logging;
using HarmonyLib;
using HypnoReplacer;
using HypnoReplacer.Data;
using HypnoReplacer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HypnoReplacer.Patchers
{
    [HarmonyPatch(typeof(VRHeadset))]
    public class VRHeadsetPatch
    {
        private static readonly Type HypnoInstanceType = AccessTools.Inner(typeof(VRHeadset), "HypnoInstance");

        private static readonly System.Reflection.FieldInfo HypnoInstancesField =
            AccessTools.Field(typeof(VRHeadset), "hypnoInstances");

        static readonly System.Reflection.FieldInfo HypnoTypeInstancesField =
            AccessTools.Field(HypnoInstanceType, "types");

        [HarmonyPatch("Start")]
        public static void Prefix(VRHeadset __instance)
        {
            Plugin.Logger.LogWarning("VRHeadset.Start postfix");

            bool found = true;
            if (HypnoInstanceType == null)
            {
                Plugin.Logger.LogError("Could not find HypnoInstanceType");
                found = false;
            }
            if (HypnoInstancesField == null)
            {
                Plugin.Logger.LogError("Could not find HypnoInstancesField");
                found = false;
            }
            if (!found)
                return;

            var array = HypnoAccessor.CreateHypnoInstanceArray();
            if (array == null) //errors should be logged by here
                return;
            
            HypnoInstancesField.SetValue(__instance, array);
            
            Plugin.Logger.LogWarning("[Prefix] Cleared HypnoInstances array!");
        }
    }
}
