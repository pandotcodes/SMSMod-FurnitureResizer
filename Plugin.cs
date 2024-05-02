using BepInEx;
using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FurnitureResizer
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public static Resizer<Display> Shelves { get; set; }
        public static Resizer<Display> Fridges { get; set; }
        public static Resizer<Display> Freezers { get; set; }
        public static Resizer<Checkout> Checkouts { get; set; }
        public static Resizer<Computer> Computer { get; set; }
        public static Resizer<Rack> Racks { get; set; }
        public static Resizer<TrashBin> TrashBin { get; set; }
        private void Awake()
        {
            Shelves = new("Shelf", Config);
            Fridges = new("Fridge", Config);
            Freezers = new("Freezer", Config);
            Checkouts = new("Checkout", Config);
            Computer = new("Computer", Config);
            Racks = new("Rack", Config);
            TrashBin = new("Trash Bin", Config);

            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            harmony.PatchAll();

            SceneManager.sceneLoaded += (a, b) =>
            {
                Plugin.TrashBin.Add(Object.FindObjectOfType<TrashBin>());
            };
        }
    }
}
