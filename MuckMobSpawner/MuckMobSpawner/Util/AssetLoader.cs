using MuckMobSpawner.Util;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace MuckMobLoader.Util
{
    internal class AssetLoader
    {
        internal static UnityEngine.Object GetAsset(string name)
        {
            if (assetBundle == null)
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MuckMobLoader.Resources.mobspawner"))
                {
                    byte[] bytes = new byte[stream.Length];
                    stream.Read(bytes, 0, bytes.Length);
                    assetBundle = AssetBundle.LoadFromMemory(bytes);
                    assetBundle.Log();
                }
            return assetBundle.LoadAsset(name);
        }

        private static AssetBundle assetBundle;
    }
}
