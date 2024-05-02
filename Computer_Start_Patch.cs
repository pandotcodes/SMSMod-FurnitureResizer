using HarmonyLib;

namespace FurnitureResizer
{
    [HarmonyPatch(typeof(Computer), "Start")]
    public static class Computer_Start_Patch
    {
        public static void Prefix(Computer __instance)
        {
            Plugin.Computer.Add(__instance);
        }
    }
}
