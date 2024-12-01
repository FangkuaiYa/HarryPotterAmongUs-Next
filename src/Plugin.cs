using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using HarryPotter.Classes;
using System.Collections.Generic;
using System.Linq;
using HarryPotter.Classes.Helpers;
using HarryPotter.Classes.Helpers.UI;
using HarryPotter.Classes.UI;
using Reactor;
using InnerNet;
using TMPro;
using UnityEngine;
using CustomOption;
using Il2CppSystem.Web.Util;
using BepInEx.Unity.IL2CPP;

namespace HarryPotter
{
    [BepInPlugin(Id, "Harry Potter", VersionString)]
    [BepInProcess("Among Us.exe")]

    //Imagine not having a custom options library? Couldn't be me
    [BepInDependency(ReactorPlugin.Id)]
    [BepInDependency(CustomOptionPlugin.Id)]

    public class Plugin : BasePlugin
    {
        public const string Id = "harry.potter.mod";
        public Harmony Harmony { get; } = new Harmony(Id);
        public const string VersionString = "1.3.0";
        public static System.Version Version = System.Version.Parse(VersionString);

        public static bool DrawHudString { get; set; } = true;
        public static float HudScale { get; set; } = 1f;

        public override void Load()
        {
            Classes.Config.LoadOptions();

            Main.Instance = new Main();

            TaskInfoHandler.Instance = new TaskInfoHandler { AllInfo = new List<ImportantTextTask>() };
            PopupTMPHandler.Instance = new PopupTMPHandler { AllPopups = new List<TextMeshPro>() };

            Harmony.PatchAll();
        }
    }

    [HarmonyPatch(typeof(StatsManager), nameof(StatsManager.AmBanned), MethodType.Getter)]
    public static class StatsManager_AmBanned
    { 
        static void Postfix(out bool __result)
        {
            __result = false;
        }
    }
    
    [HarmonyPatch(typeof(PingTracker), nameof(PingTracker.Update))]
    public static class PingTracker_Update
    {
        static void Postfix(PingTracker __instance)
        {
            __instance.text.alignment = TextAlignmentOptions.TopRight;
            __instance.text.margin = new Vector4(0, 0, 0.5f, 0);
            __instance.text.transform.localPosition = new Vector3(0, 0, 0);
            Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
            __instance.text.transform.position = new Vector3(topRight.x - 0.1f, topRight.y - 1.6f);
            __instance.text.text = $"<size=130%><#FF8503>Harry Potter v{Plugin.Version.ToString()}</size>" +
                "\n<#FFFFFFFF>Created by: <#00FFFF>FangKuai" +
                "\n<#FFFFFFFF>Original by: <#7289DAFF>Hunter101#1337" +
                "\n<#FFFFFFFF>Art by: <#E67E22FF>PhasmoFireGod" +
                $"\n<#FFFFFFFF>Ping: {AmongUsClient.Instance.Ping} ms";
        }
    }

    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start))]
    public static class LogoPatch
    {
        public static SpriteRenderer renderer;
        private static PingTracker instance;
        static void Postfix(PingTracker __instance)
        {
            var amongUsLogo = GameObject.Find("bannerLogo_AmongUs");
            if (amongUsLogo != null)
            {
                amongUsLogo.transform.localScale *= 0.6f;
                amongUsLogo.transform.position += Vector3.up * 0.25f;
            }

            var torLogo = new GameObject("bannerLogo_TOR");
            torLogo.transform.position = Vector3.up;
            renderer = torLogo.AddComponent<SpriteRenderer>();

            renderer.sprite = LoadResources.loadSpriteFromResources("HarryPotter.Resources.Banner.png", 300f);

            instance = __instance;
        }
    }
}