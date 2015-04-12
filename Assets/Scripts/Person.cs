using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Schema;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;


/// <summary>
/// This datatype represents a Person in the game
/// </summary>
public class Person
{


    private Book _book;

    /// <summary>
    /// The town where the person lives. It influences in what the person believes in.
    /// </summary>
    private Town HomeTown { get; set; }


    /// <summary>
    /// Defines how easy it is to control this person. This value is set when a new Person is created and wont't change.
    /// 100 % is completele controllable 0 % is not controllable at all (indipendent)
    /// </summary>
    private float Controllable { get; set; }

    /// <summary>
    /// Defines how violent the personi is in general. This value is set when a new Person is created and wont't change.
    /// 100 % is very agressive, 0 % not agressive at all
    /// </summary>
    private float Violent { get; set; }

    /// <summary>
    /// Defines how happe this person is. This value is influenced by the profets behavior and rules.
    /// A happy person is easier to handle, while unhappy / dissatisfied person is more likely to revolt / turn ageints the prophet
    /// </summary>
    public  float Happines { get; private set; }

    public bool IsFollower { get; private set; }

    private List<BeliefSet> BeliefList;
    private int numberBeliefs;


    /// <summary>
    /// Constructor
    /// </summary>
    public Person(Town town)
    {
        this.numberBeliefs = 3;
        this.BeliefList = new List<BeliefSet>();
        this.HomeTown = town;
        this.Controllable = InitControllableViolent();
        this.Violent = InitControllableViolent();
        this.Happines = 70; // 70% Happy as std
        this.InitBeliveList();
    }

    /// <summary>
    /// Creates a random number for the default character traits that don't change during the game
    /// </summary>
    private float InitControllableViolent()
    {
        return Random.Range(0, 100);
    }

    private void InitBeliveList()
    {
        while (BeliefList.Count != numberBeliefs)
        {
            bool isDuplicate = false;
            var candidate = Config.Beliefs[Random.Range(0, HomeTown.GetBeliefs().Count)];
            if (BeliefList.Count == 0)
            {
                BeliefList.Add(candidate);
                continue;
            }
            foreach (var beliefSet in BeliefList)
            {
                if (candidate.beliefName == beliefSet.beliefName)
                {
                    isDuplicate = true;
                    break;
                }

            }
            if (!isDuplicate)
            {
                BeliefList.Add(candidate); 
            }
        }
    }

    /// <summary>
    /// Updates the mood of the person refering to the rules of "The Book"
    /// </summary>
    public void UpdateMood()
    {
        //when there is an update in "The Book" -> chek how it is relating to the BelieveList  -> Happiness--, Happines++ ore neutral
        //look it up and change values
        var ruels = _book.GetActiveRules();

        float pos = 0;
        float neg = 0;
        foreach (var rule in ruels)
        {
            if (DoesFit(rule) > 0)
            {
                pos++;
            }
            else
            {
                neg++;
            }
            Happines = Math.Max(1.0f, pos/neg);
            Debug.Log("Happiness: " + Happines);
        }
    }

    private float DoesFit(Rule rule)
    {
        float retval = 0;
        foreach (var beliefSet in BeliefList)
        {
            if (beliefSet.beliefName == rule.RuleName)
            {
                retval += 1;
            }
            else
            {
                foreach (var associated in beliefSet.associatedBeliefs)
                {
                    if(associated.Key == rule.RuleName)
                    {
                        retval += associated.Value;
                    }
                }
            }
        }
        return retval;
    }




}
