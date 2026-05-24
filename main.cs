using BepInEx;
using HarmonyLib;
using UnityEngine;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

[BepInPlugin(ModGUID, ModName, ModVersion)]
public class Plugin : BaseUnityPlugin
{
	public const string ModGUID = "zopthemop.zoomoutmore";
	public const string ModName = "Zoom Out More";
	public const string ModVersion = "1.0.0";

    private void Awake()
    {
        Harmony harmony = new(ModGUID);
        harmony.PatchAll();
    }

	[HarmonyPatch(typeof(GameCamera), "Awake")]
	public static class GameCamera_Awake_Patch
	{
		private static void Prefix(GameCamera __instance)
		{
			__instance.m_maxDistance = 9f;
			__instance.m_maxDistanceBoat = 18f;
		}
	}
}
