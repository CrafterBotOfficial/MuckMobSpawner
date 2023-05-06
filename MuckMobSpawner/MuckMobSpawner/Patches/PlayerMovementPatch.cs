using HarmonyLib;
using MuckMobLoader.Util;
using MuckMobSpawner.Util;
using Steamworks;
using UnityEngine;

namespace MuckMobLoader.Patches
{
    [HarmonyPatch(typeof(PlayerMovement), "Start", MethodType.Normal)]
    internal class PlayerMovementPatch
    {
        [HarmonyPostfix]
        private static void Hook()
        {
            "Hook execute".Log(MuckMobSpawner.Util.LogType.Bold);

            bool IsConnected = SteamClient.IsValid;
            bool IsMaster = IsConnected ? SteamManager.Instance.currentLobby.IsOwnedBy(SteamClient.SteamId) : false;

            if (IsMaster || !IsConnected)
                MakeController();

            void MakeController()
            {
                Transform Menu = GameObject.Instantiate(AssetLoader.GetAsset("Menu") as GameObject).transform;
                Menu.parent = GameObject.Find("UI (1)").transform;
                new Core.MenuController(Menu);
            }
        }
    }
}
