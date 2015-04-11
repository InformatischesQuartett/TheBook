using System.Collections.Generic;
using UnityEngine;
using System.Collections;

/// <summary>
/// This datatype represents a Person in the game
/// </summary>
public class Person {


    private string HomeTown { get; set; }


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
    /// A happy person is easier to handel, while unhappi / dissatisfied person is more likely to revolt / turn ageints the prophet
    /// </summary>
    private float Happines { get; set; }

    private List<Rule> BelieveList; 

    /// <summary>
    /// Constructor
    /// </summary>
    public Person(string hometown)
    {
        this.HomeTown = hometown;
        this.Controllable = ControllableViolent();
        this.Violent = ControllableViolent();
        this.Happines = 70; // 70% Happy as std

        //Randomlly picking 3 rules in respect of the hometown of the person
    }

    /// <summary>
    /// Creates a random number for the default character traits that don't change during the game
    /// </summary>
    private float ControllableViolent()
    {
        return Random.Range(0, 100);
    }


    /// <summary>
    /// Updates the mood of the person refering to the rules of "The Book"
    /// </summary>
    public void UpdateMood()
    {

    }

    //when there is an update in "The Book" -> chek how it is relating to the BelieveList  -> Happiness--, Happines++ ore neutral
    

}
