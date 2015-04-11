using System.Collections.Generic;
using UnityEngine;
using System.Collections;


/// <summary>
/// This datatypes resebles a town in numbers.
/// If the majority of the ppl how live there are folloing you,
/// which beliefs are ther in this town, etc (numbers numbers, numbers)
/// </summary>
public class Town {

    /// <summary>
    /// Name of the Town
    /// </summary>
    public  string Name { get; private set; }

    /// <summary>
    /// Nummber of ppl living in this town
    /// </summary>
    private int NumberInhabitants { get; set; }

    /// <summary>
    /// thisngs ppl believe in this town
    /// </summary>
    private List<Belief> BeliefsList { get; set; }

    /// <summary>
    /// Number ppl who are folloing you in this town
    /// </summary>
    private int Followers { get; set; }

    public Town(string name)
    {
        this.Name = name;
        this.NumberInhabitants = 50; //TODO: dummy Value

        BeliefsList = new List<Belief>();
    }
}
