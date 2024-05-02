using HarmonyLib;

namespace FurnitureResizer
{
    [HarmonyPatch(typeof(Checkout), "Start")]
    public static class Checkout_Start_Patch
    {
        public static void Prefix(Checkout __instance)
        {
            Plugin.Checkouts.Add(__instance);
        }
    }
}
