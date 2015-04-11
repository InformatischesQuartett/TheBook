using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public static class Config
{
    private static readonly string _configFile = Application.streamingAssetsPath + @"\config.json";
    private static readonly string _beliefsPath = Application.streamingAssetsPath + @"\Beliefs";
    public static float CharacterWalkSpeed { get; private set; }
    public static float MenuTransitionSpeed { get; private set; }
    public static float MapMouseEmulationSpeed { get; private set; }
    public static Texture2D Cursor { get; private set; }
    public static List<BeliefSet> Beliefs { get; private set; }


    static Config()
    {
        Cursor = (Texture2D)Resources.Load("cursor");

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
                var belief = JsonConvert.DeserializeObject<BeliefSet>(filecontent);
                Beliefs.Add(belief);
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
    public string rule;
    public Dictionary<string, float> associatedBeliefs;
    public Dictionary<string, string> dialogues;
    //TODO: speeches

}

public struct BeliveAso
{
    
}