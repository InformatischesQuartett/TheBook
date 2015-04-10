using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public static class Config
{
    private static readonly string _configPath = Application.streamingAssetsPath;
    public static float CharacterWalkSpeed;

    static Config()
    {
        var configContent = File.ReadAllText(_configPath + "/config.json");
        var conf = JsonConvert.DeserializeObject<ConfigSet>(configContent);

        CharacterWalkSpeed = conf.CharacterWalkSpeed;
    }
}

internal struct ConfigSet
{
    public float CharacterWalkSpeed;
}