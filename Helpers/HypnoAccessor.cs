using HarmonyLib;
using HypnoReplacer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HypnoReplacer.Helpers
{
    internal static  class HypnoAccessor
    {
        static readonly Type HypnoInstanceType = AccessTools.Inner(typeof(VRHeadset), "HypnoInstance");
        static readonly Type HypnoEnumType = AccessTools.Inner(typeof(VRHeadset), "HypnoType");

        //static readonly System.Reflection.FieldInfo HypnoTypeField =
        //    AccessTools.Field(HypnoInstanceType, "types");
        //private static readonly System.Reflection.FieldInfo HypnoInstancesField =
        //    AccessTools.Field(typeof(VRHeadset), "hypnoInstances");


        internal static Array CreateHypnoTypeArray(string[] hypnoTypes)
        {
            int newSize = hypnoTypes.Length;

            var array = Array.CreateInstance(HypnoEnumType, newSize);

            if(array == null)
            {
                Plugin.Logger.LogError("Could not create HypnoTypeArray");
                return null;
            }

            for (int i = 0; i < newSize; i++)
            {
                object enumValue = Enum.Parse(HypnoEnumType, hypnoTypes[i]);

                array.SetValue(enumValue, i);
            }

            return array;
        }

        internal static object CreateHypnoInstance(Array hypnoTypes, SpriteData spriteData, int xpGiven)
        {
            var instance = AccessTools.CreateInstance(HypnoInstanceType);

            if(instance == null)
            {
                Plugin.Logger.LogError("Could not create HypnoInstance");
                return null;
            }
            Sprite sprite = spriteData.Sprite;

            AccessTools.Field(HypnoInstanceType, "sprite").SetValue(instance, sprite);
            AccessTools.Field(HypnoInstanceType, "types").SetValue(instance, hypnoTypes);
            AccessTools.Field(HypnoInstanceType, "XPGiven").SetValue(instance, xpGiven);

            return instance;
        }

        internal static Array CreateHypnoInstanceArray()
        {
            List<object> list = new List<object>();
            foreach(var spriteData in SpriteDataHelper.HypnoInstances.Values)
            {
                Sprite sprite = spriteData.Sprite;
                Array hypnoTypes = CreateHypnoTypeArray(spriteData.HypnoTypes);
                if(hypnoTypes == null)
                {
                    Plugin.Logger.LogError("Could not create HypnoTypeArray");
                    return null;
                }
                int xpGiven = spriteData.XpGiven;
                object instance = CreateHypnoInstance(hypnoTypes, spriteData, xpGiven);

                if(instance == null)
                {
                    Plugin.Logger.LogError("Could not create HypnoInstance in CreateHypnoInstanceArray");
                    return null;
                }
                list.Add(instance);
            }

            int newSize = list.Count;
            var array = Array.CreateInstance(HypnoInstanceType, newSize);
            for (int i = 0; i < newSize; i++)
            {
                array.SetValue(list[i], i);
            }
            return array;

        }

    }
}
