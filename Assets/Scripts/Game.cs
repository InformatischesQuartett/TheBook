using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using UnityEngine;

/// <summary>
///     This is the main class for this game. This class will never be destroyed
/// </summary>
public static class Game
{
    private static readonly string _configFile = @"config";
    private static readonly string _belieflistFile = @"belieflist";
    private static readonly string _beliefsPath = @"Beliefs";
    private static ConfigSet _config;
    private static readonly List<Town> _towns = new List<Town>();
    public static Rule MasterRule = new Rule("Thou shalt not kill.", "MasterRule");
    public static Town CurrenTown;
    public static Config testConfig;

    static Game()
    {
        LoadConfig();
        LoadBeliefs();
        LoadConfigXML();

        Debug.Log(testConfig.CharacterWalkSpeed);

        Debug.Log("The Game");
        _towns.Add(new Town("Clayton"));
        _towns.Add(new Town("Desertville"));
        _towns.Add(new Town("Orienta"));
    }

    public static ConfigSet Config
    {
        get { return _config; }
        set { _config = value; }
    }

    public static List<Town> GetTowns()
    {
        return _towns;
    }

    private static void LoadConfig()
    {
        var configfileTa = Resources.Load<TextAsset>(_configFile);
        Config = JsonConvert.DeserializeObject<ConfigSet>(configfileTa.text);

        _config.Cursor = (Texture2D)Resources.Load("cursor");
    }

    private static void LoadConfigXML()
    {
        var serializer = new XmlSerializer(typeof(Config));
        var configfileTa = Resources.Load<TextAsset>(_configFile + "2");
        testConfig = serializer.Deserialize(new StringReader(configfileTa.text)) as Config;
    }

    private static void LoadBeliefs()
    {
        var belieflistTa = Resources.Load<TextAsset>(_belieflistFile);
        var belieflist = JsonConvert.DeserializeObject<string[]>(belieflistTa.text);

        _config.Beliefs = new List<BeliefSet>();

        for (var i = 0; i < belieflist.Length; i++)
        {
            var beliefTa = Resources.Load<TextAsset>(_beliefsPath + "/" + belieflist[i]);
            _config.Beliefs.Add(JsonConvert.DeserializeObject<BeliefSet>(beliefTa.text));
        }
    }
}


public struct ConfigSet
{
    public List<BeliefSet> Beliefs;
    public float CharacterWalkSpeed;
    public Texture2D Cursor;
    public float MapMouseEmulationSpeed;
    public float MenuTransitionSpeed;
}

public struct BeliefSet
{
    public Dictionary<string, float> associatedBeliefs;
    public string beliefName;
    public Dictionary<string, string> dialogues;
    public string rule;
}
