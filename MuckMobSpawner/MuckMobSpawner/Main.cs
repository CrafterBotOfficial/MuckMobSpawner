using BepInEx;
using HarmonyLib;
using MuckMobLoader.Core;
using MuckMobSpawner.Util;
using System;
using System.Net.Http;
using System.Reflection;

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
        internal static Version OnlineVersion;

        private void Awake()
        {
            Extensions._logSource = Logger;
            $"Init : {NAME}".Log();

            new Harmony(GUID).PatchAll(Assembly.GetExecutingAssembly());
            Configuration.Load();

            OnlineVersion = GetOnlineVersion();
            if (OnlineVersion != null)
                if (OnlineVersion.Build > new Version(VERSION).Build)
                {
                    $"New version available : {OnlineVersion}".Log(Util.LogType.Warning);
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
                e.Log(Util.LogType.Error);
                return null;
            }
        }
    }
}
