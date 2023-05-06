using BepInEx;
using MuckMobSpawner.Util;
using System;
using System.Net.Http;

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
        internal static bool VersionInvalid;

        private void Awake()
        {
            $"Init : {NAME}".Log();

            Version onlineVersion = GetOnlineVersion();
            if (onlineVersion != null)
                if (onlineVersion.Build > new Version(VERSION).Build)
                {
                    $"New version available : {onlineVersion}".Log(LogType.Warning);
                    VersionInvalid = true;
                }

        }

        private Version GetOnlineVersion()
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    byte[] bytes = httpClient.GetByteArrayAsync(GIT_VERSION).Result;
                    string RawVersion = Convert.ToBase64String(bytes);
                    return new Version(RawVersion);
                }
            }
            catch (Exception e)
            {
                e.Log(LogType.Error);
                return null;
            }
        }
    }
}
