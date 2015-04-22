using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

public class Belief {
    public Dictionary<string, float> associatedBeliefs;
    public string beliefName;
    public Dictionary<string, string> dialogues;
    public string rule;
}
