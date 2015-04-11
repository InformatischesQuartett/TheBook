using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public static class Config
{
    private static readonly string _configFile = Application.streamingAssetsPath + @"\config.json";
    private static readonly string _beliefsPath = Application.streamingAssetsPath + @"\Beliefs";
    public static float CharacterWalkSpeed;
    public static float MenuTransitionSpeed;
    public static float MapMouseEmulationSpeed;
    public static List<BeliefSet> Beliefs { get; private set; }


    static Config()
    {
        var configContent = File.ReadAllText(_configFile);
        var conf = JsonConvert.DeserializeObject<ConfigSet>(configContent);

        CharacterWalkSpeed = conf.CharacterWalkSpeed;
        MenuTransitionSpeed = conf.MenuTransitionSpeed;
        MapMouseEmulationSpeed = conf.MapMouseEmulationSpeed;

        Beliefs = new List<BeliefSet>();
        foreach (string file in Directory.GetFiles(_beliefsPath))
        {
            if (file.EndsWith(".json"))
            {
                string filecontent = File.ReadAllText(file);
                //var belief = JsonConvert.DeserializeObject<BeliefSet>(filecontent);
                //Beliefs.Add(belief);
            }
        }
    }
}

internal struct ConfigSet
{
    public float CharacterWalkSpeed;
    public float MenuTransitionSpeed;
    public float MapMouseEmulationSpeed;
}

public struct BeliefSet
{
    public string beliefName;
    public Dictionary<string, float> associatedBeliefs;
}

public struct BeliveAso
{
    
}