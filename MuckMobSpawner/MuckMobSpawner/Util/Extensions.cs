using MuckMobSpawner;
using UnityEngine;

namespace MuckMobSpawner.Util
{
    internal static class Extensions
    {
        internal static void Log(this object obj, LogType logType = LogType.Info)
        {
            string NewMessage = $"**[{Main.NAME}]** " + obj;
            switch (logType)
            {
                case LogType.Info:
                    Debug.Log(NewMessage);
                    break;
                case LogType.Warning:
                    Debug.Log(NewMessage);
                    break;
                case LogType.Error:
                    Debug.Log(NewMessage);
                    break;
            }
        }
    }

    internal enum LogType
    {
        Info,
        Warning,
        Error
    }
}
