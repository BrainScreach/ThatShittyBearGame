using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThatShittyBearGame.Settings
{
    public class UserConfiguration
    {
        public const string CONFIG_FILE_PATH = "user://config.cfg";
        public const string MAIN_CONFIG_SECTION = "whole";
        public const string USER_CONFIGURATION = "config";

        public static UserConfiguration Instance { get; private set; }

        static UserConfiguration()
        {
            var instance = Load();
            if (instance == null)
                Instance = new UserConfiguration();
            else
                Instance = instance;
        }

        static UserConfiguration Load()
        {
            var config = new ConfigFile();
            var err = config.Load(CONFIG_FILE_PATH);
            if (err != Error.Ok)
                return null;

            string val = (string)config.GetValue(MAIN_CONFIG_SECTION, USER_CONFIGURATION, string.Empty);
            if (string.IsNullOrEmpty(val))
                return null;

            return System.Text.Json.JsonSerializer.Deserialize<UserConfiguration>(val);
        }


        public float LevelLength { get; set; } = 50;
        public float MainVolume { get; set; } = 1f;

        public void Save()
        {
            var config = new ConfigFile();
            config.SetValue(MAIN_CONFIG_SECTION, USER_CONFIGURATION, System.Text.Json.JsonSerializer.Serialize(this));
            config.Save(CONFIG_FILE_PATH);
        }
    }
}
