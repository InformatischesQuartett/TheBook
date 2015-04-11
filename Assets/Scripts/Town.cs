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
    public string Name { get; private set; }

    /// <summary>
    /// Nummber of ppl living in this town
    /// </summary>
    private int NumberInhabitants { get; set; }

    /// <summary>
    /// thisngs ppl believe in this town
    /// </summary>
    private List<Belief> BeliefsList = new List<Belief>();


    /// <summary>
    /// Inhabitants of this town, a List of Persons
    /// </summary>
    private List<Person> Inhabitants = new List<Person>();

    public List<Person> GetInhabitants()
    {
        return Inhabitants;
    }

    /// <summary>
    /// Number ppl who are folloing you in this town
    /// </summary>
    public int Followers { get; private set; }

    /// <summary>
    /// is true the town is Convertet. the town is converted if 70% of the inhabitants are followers
    /// </summary>
    public bool IsConverted { get; private set; }


    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="name"></param> is the name of teh town
    public Town(string name)
    {
        this.Name = name;
        this.NumberInhabitants = 50; //TODO: dummy Value

        InitInhabitants();
    }

    /// <summary>
    /// Initialises the List of Inhabinants
    /// </summary>
    private void InitInhabitants()
    {
        for (int i = 0; i < NumberInhabitants; i++)
        {
            Inhabitants.Add(new Person(this));
        }
    }


    /// <summary>
    /// Is called to update the Moods of all ehe iunhabitants and the state of the town (IsConverted)
    /// </summary>
    private void UpdateTown()
    {
        //update the mood of all inhabitants
        foreach (var inhabitant in Inhabitants)
        {
            inhabitant.UpdateMood();
        }

        //update the number of followerd regarding their new moods
        foreach (var inhabitant in Inhabitants)
        {
            if (inhabitant.IsFollower)
            {
                Followers++;
            }
        }

        //sets IsConverted
        if (Followers/Inhabitants.Count >= 0.7f)
        {
            IsConverted = true;
        }
        else
        {
            IsConverted = false;
        }
    }
}
