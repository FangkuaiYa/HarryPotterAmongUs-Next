﻿﻿using HarmonyLib;
using HarryPotter.Classes;
using HarryPotter.Classes.Roles;
using UnityEngine;

namespace HarryPotter.Patches
{
    [HarmonyPatch(typeof(IntroCutscene._ShowTeam_d__21), nameof(IntroCutscene._ShowTeam_d__21.MoveNext))]
    class IntroCutscene_ShowTeam_d__21_MoveNext
    {
        static void Prefix(IntroCutscene._ShowTeam_d__21 __instance)
        {
            ModdedPlayerClass localPlayer = Main.Instance.GetLocalModdedPlayer();
            if (!localPlayer._Object.Data.Role.IsImpostor) __instance.__4__this.TeamTitle.text = "Muggle";
        }

    }
    [HarmonyPatch(typeof(IntroCutscene._ShowRole_d__24), nameof(IntroCutscene._ShowRole_d__24.MoveNext))]
    class IntroCutscene_ShowRole_d__24_MoveNext
    {
        static void Postfix(IntroCutscene._ShowRole_d__24 __instance)
        {
            ModdedPlayerClass localPlayer = Main.Instance.GetLocalModdedPlayer();
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
