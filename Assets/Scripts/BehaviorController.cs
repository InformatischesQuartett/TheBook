using System.Collections.Generic;
using UnityEngine;
using System.Collections;

/// <summary>
/// Mein class to controll the behavior of the persons and in respect to "The Book" and their believes
/// </summary>
public class BehaviorController : MonoBehaviour
{


    private List<Person> _personList { get; set; }

	// Use this for initialization
	void Start () {
	    _personList = new List<Person>();
        //init _personList

        _personList.Add(new Person("FuWa"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// This is called when ever ther is a change in "The Book" -> updating the mood of the Persons
    /// </summary>
    private void OnUpdateBook()
    {
        //Iterate over list of persons and check for conflicts
        foreach (var person in _personList)
        {
            person.UpdateMood();
        }
    }
}
