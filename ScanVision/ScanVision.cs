using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using ScanVision.Patches;

namespace ScanVision
{

    public class PLUGIN_INFO
    {
        public const string PLUGIN_GUID = "yunussahinio.lethalcompanyscanvision";
        public const string PLUGIN_NAME = "Scan Vision";
        public const string PLUGIN_VERSION = "0.0.1";
    }


    [BepInPlugin(PLUGIN_INFO.PLUGIN_GUID, PLUGIN_INFO.PLUGIN_NAME, PLUGIN_INFO.PLUGIN_VERSION)]
    public class ScanVision : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony(PLUGIN_INFO.PLUGIN_GUID);
        internal static ManualLogSource Log;
        void Awake()
        {
            Log = Logger;
            Log.LogInfo("__________________Awake");
            harmony.PatchAll(typeof(ScanVision));
            harmony.PatchAll(typeof(HudManagerPatch));
            harmony.PatchAll(typeof(AudioSourcePatch));

        }
    }
}