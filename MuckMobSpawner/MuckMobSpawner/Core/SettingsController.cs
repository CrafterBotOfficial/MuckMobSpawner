using System;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace MuckMobLoader.Core
{
    internal class SettingsController
    {
        internal static SettingsController settingsController;

        private static string SettingsPath;
        private static Settings _Settings;
        public SettingsController()
        {
            settingsController = this;
            SettingsPath = Application.dataPath + "/muckmobloader_settings.xml";
            Reload();
        }

        private void Reload()
        {
            if (!File.Exists(SettingsPath))
                MakeFile();
            using (Stream stream = File.OpenRead(SettingsPath))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Settings));
                _Settings = (Settings)xmlSerializer.Deserialize(stream);
            }
        }
        private void MakeFile(bool NewRewrite = true)
        {
            using (Stream stream = File.Create(SettingsPath))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Settings));
                xmlSerializer.Serialize(stream, NewRewrite ? new Settings() : _Settings);
            }
            Reload();
        }

        internal static Version Version
        {
            get
            {
                return _Settings._Version;
            }
            set
            {
                _Settings._Version = value;
                settingsController.MakeFile(false);
            }
        }
        internal static PageHandler pageHandler
        {
            get
            {
                return _Settings.pageHandler;
            }
            set
            {
                _Settings.pageHandler = value;
                settingsController.MakeFile(false);
            }
        }
    }

    [Serializable]
    public class Settings
    {
        public Version _Version { get; set; }
        public PageHandler pageHandler { get; set; }
        public Settings() { }
    }
}
