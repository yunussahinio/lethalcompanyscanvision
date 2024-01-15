using GameNetcodeStuff;
using HarmonyLib;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.Controls.AxisControl;

namespace ScanVision.Patches
{

    [HarmonyPatch(typeof(HUDManager))]
    internal class HudManagerPatch
    {
        public static bool EnableScanVision = false;
        public static bool AnimateScanVision = false;


        [HarmonyPrefix]
        [HarmonyPatch("Update")]
        public static void Update()
        {
            if (!AnimateScanVision) return;

            PlayerControllerB player = StartOfRound.Instance.localPlayerController;
            if (player == null) return;

            if (EnableScanVision)
            {
                //ScanVision.Log.LogInfo("Update EnableScanVision");

                player.nightVision.intensity += player.nightVision.intensity >= 6500f ? 50f : 300f;
                player.nightVision.range += 100f;

                if (player.nightVision.intensity >= 7500f)
                {
                    player.nightVision.range = 100000f;
                    player.nightVision.shadowStrength = 0f;
                    player.nightVision.shadows = 0;
                    player.nightVision.shape = (LightShape)2;
                    EnableScanVision = false;
                }

            }
            if (!EnableScanVision)
            {
                //ScanVision.Log.LogInfo("Update !EnableScanVision");

                player.nightVision.intensity -= 200f;
                player.nightVision.range -= 100f;

                if (player.nightVision.intensity <= 366.9317f)
                {
                    player.nightVision.intensity = 366.9317f;
                    player.nightVision.range = 12f;
                    player.nightVision.shadowStrength = 1f;
                    player.nightVision.shadows = 0;
                    player.nightVision.shape = 0;

                    AnimateScanVision = false;

                    ScanVision.Log.LogInfo("ScanVision Disabled");

                }
            }
            //ScanVision.Log.LogInfo(player.nightVision.intensity);

        }


    }
}
