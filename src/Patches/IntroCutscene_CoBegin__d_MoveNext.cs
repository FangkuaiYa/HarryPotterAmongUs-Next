﻿﻿using HarmonyLib;
using HarryPotter.Classes;
using HarryPotter.Classes.Roles;
using UnityEngine;

namespace HarryPotter.Patches
{
    [HarmonyPatch(typeof(IntroCutscene._CoBegin_d__19), nameof(IntroCutscene._CoBegin_d__19.MoveNext))]
    class IntroCutscene_CoBegin__d_MoveNext
    {
        static void Prefix(IntroCutscene._CoBegin_d__19 __instance)
        {
            __instance.__4__this.IntroStinger = Main.Instance.Assets.HPTheme;
        }
        
        static void Postfix(IntroCutscene._CoBegin_d__19 __instance)
        {
            ModdedPlayerClass localPlayer = Main.Instance.GetLocalModdedPlayer();
            if (!localPlayer._Object.Data.Role.IsImpostor) __instance.__4__this.TeamTitle.text = "Muggle";
            if (localPlayer.Role == null) return;
            localPlayer.Role.ResetCooldowns();
            __instance.__4__this.ImpostorText.gameObject.SetActive(true);
            __instance.__4__this.ImpostorText.transform.localScale = new Vector3(0.7f, 0.7f);
            __instance.__4__this.RoleText.text = localPlayer.Role.RoleName;
            __instance.__4__this.RoleText.color = localPlayer.Role.RoleColor;
            __instance.__4__this.RoleBlurbText.text = localPlayer.Role.IntroString;
            __instance.__4__this.RoleBlurbText.color = localPlayer.Role.RoleColor;
            __instance.__4__this.BackgroundBar.material.color = localPlayer.Role.RoleColor2;
        }
    }
}
