using HarmonyLib;
using System;

namespace FurnitureResizer
{
    [HarmonyPatch(typeof(Display), "Initialize")]
    public static class Display_Initialize_Patch
    {
        public static void Prefix(Display __instance)
        {
            switch(__instance.DisplayType)
            {
                case DisplayType.SHELF: Plugin.Shelves.Add(__instance); break;
                case DisplayType.FRIDGE: Plugin.Fridges.Add(__instance); break;
                case DisplayType.FREEZER: Plugin.Freezers.Add(__instance); break;
                default: throw new Exception("What the fuck is a crate.");
            }
        }
    }
}
