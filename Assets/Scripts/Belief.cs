using System.Collections.Generic;

public class Belief
{
    public string Name { get; private set; }
    public List<Rule> Rules { get; private set; }

    public Belief(string name)
    {
        Name = name;
    }


}
