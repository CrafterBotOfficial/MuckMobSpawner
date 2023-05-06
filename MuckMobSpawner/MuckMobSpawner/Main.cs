using BepInEx;

namespace MuckMobSpawner
{
    [BepInPlugin(GUID, NAME, VERSION)]
    internal class Main : BaseUnityPlugin
    {
        internal const string
            GUID = "crafterbot.mobspawner",
            NAME = "MuckMobSpawner",
            VERSION = "1.0.0",
            GIT_VERSION = "";
    }
}
