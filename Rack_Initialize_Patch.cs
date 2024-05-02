using HarmonyLib;

namespace FurnitureResizer
{
    [HarmonyPatch(typeof(Rack), "Initialize")]
    public static class Rack_Initialize_Patch
    {
        public static void Prefix(Rack __instance)
        {
            Plugin.Racks.Add(__instance);
        }
    }
}
