using HarmonyLib;
using UnityEngine;

namespace ScanVision.Patches
{
    [HarmonyPatch(typeof(AudioSource))]
    internal class AudioSourcePatch
    {
        [HarmonyPatch("PlayOneShotHelper", new[] { typeof(AudioSource), typeof(AudioClip), typeof(float) })]
        [HarmonyPrefix]
        public static void PlayOneShotHelper(AudioSource source, ref AudioClip clip, float volumeScale)
        {
            if (clip == HUDManager.Instance?.scanSFX) {
                HudManagerPatch.EnableScanVision = true;
                HudManagerPatch.AnimateScanVision = true;
                ScanVision.Log.LogInfo(HudManagerPatch.EnableScanVision);
                ScanVision.Log.LogInfo(HudManagerPatch.AnimateScanVision);
            }
        }
    }
}
