using BepInEx;
using BepInEx.Configuration;
using UnityEngine;

namespace MuckMobLoader.Core
{
    internal class Configuration
    {
        internal static ConfigEntry<KeyCode> OpenMenuKey { get; private set; }
        internal static ConfigEntry<KeyCode> PrevKey { get; private set; }
        internal static ConfigEntry<KeyCode> NextKey { get; private set; }
        public static void Load()
        {
            var config = new ConfigFile(Paths.ConfigPath + "/mobspawner.cfg", true);
            OpenMenuKey = config.Bind("General", "KeyOpenMenu", KeyCode.F1, "The key to open the mob spawner menu");
            PrevKey = config.Bind("General", "KeyPrev", KeyCode.LeftArrow, "The key to go to the previous page");
            NextKey = config.Bind("General", "KeyNext", KeyCode.RightArrow, "The key to go to the next page");
        }
    }
}
