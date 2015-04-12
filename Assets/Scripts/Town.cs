using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters;
using Random = UnityEngine.Random;
using UnityEngine;
using Debug = UnityEngine.Debug;


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
    private List<BeliefSet> BeliefsList = new List<BeliefSet>();

    public List<BeliefSet> GetBeliefs()
    {
        return this.BeliefsList;
    }

    private int _numberBelieves = 5;

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
        InitBeliefs();
        InitInhabitants();
    }

    /// <summary>
    /// Initialise the believes a town has
    /// </summary>
    private void InitBeliefs()
    {
        int size = Config.Beliefs.Count;
        int negBeliefs = 0;
        int maxNegBeliefs = 2;
        while (BeliefsList.Count != _numberBelieves)
        {
            bool isDuplicate = false;
            var candidate = Config.Beliefs[Random.Range(0, size)];
            int candidateNegBeliefs = 0;
            //empty List, first entry
            if (BeliefsList.Count == 0)
            {
                BeliefsList.Add(candidate);
                continue;
            }
            foreach (var beliefSet in BeliefsList)
            {
                if (candidate.beliefName == beliefSet.beliefName)
                {
                    isDuplicate = true;
                    break;
                }
                
            }
            if (isDuplicate)
            {
                continue;
            }
            foreach (var existingBelief in  BeliefsList)
            {

                foreach (var belief in candidate.associatedBeliefs)
                {
                    if (belief.Value < 0)
                    {
                        if (existingBelief.beliefName == belief.Key)
                        {
                            candidateNegBeliefs++;
                        }
                    }
                }
            }

            if (negBeliefs + candidateNegBeliefs > maxNegBeliefs)
            {
                continue;
            }
            else
            {
                BeliefsList.Add(candidate);
                negBeliefs += candidateNegBeliefs;
            }
        }
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
    public void OnUpdateBook(object sender, EventArgs eventArgs)
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

        // IsConverted
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
