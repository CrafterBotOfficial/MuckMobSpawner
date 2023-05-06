using BepInEx;
using MuckMobSpawner.Util;
using System;

namespace MuckMobSpawner
{
    [BepInPlugin(GUID, NAME, VERSION)]
    internal class Main : BaseUnityPlugin
    {
        internal const string
            GUID = "crafterbot.mobspawner",
            NAME = "MuckMobSpawner",
            VERSION = "1.0.0",
            GIT_VERSION = "https://raw.githubusercontent.com/CrafterBotOfficial/MuckMobSpawner/main/Data";

        private void Awake()
        {
            $"Init : {NAME}".Log();
        }

        private Version GetOnlineVersion()
        {
            return null;
        }
    }
}
