using BepInEx.Logging;

namespace MuckMobSpawner.Util
{
    internal static class Extensions
    {
        public static ManualLogSource _logSource;
        internal static void Log(this object obj, LogType logType = LogType.Info)
        {
            string NewMessage = $" **[{Main.NAME}]** " + obj;

            switch (logType)
            {
                case LogType.Info:
                    _logSource.LogInfo(NewMessage);
                    break;
                case LogType.Warning:
                    _logSource.LogWarning(NewMessage);
                    break;
                case LogType.Error:
                    _logSource.LogError(NewMessage);
                    break;
                case LogType.Bold:
                    _logSource.LogMessage(NewMessage);
                    break;
            }
        }
    }

    internal enum LogType
    {
        Info,
        Warning,
        Error,
        Bold
    }
}
