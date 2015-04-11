using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Book : MonoBehaviour {

    /*all rules that are in the book*/
    private List<String> ruleList = new List<String>();
    private Game _game;
    private event EventHandler _updateBookEvent;
	
    // Use this for initialization
	void Start ()
	{
	    _game = GameObject.Find("Game").GetComponent<Game>();

	    foreach (var town in _game.GetTowns())
	    {
	        _updateBookEvent += town.OnUpdateBook;
	    }
        
	}
	
	// Update is called once per frame
	void Update () 
    {

	}



    private void _activeRule(String key)
    {
        
    }

    private void _addNewRule(String key)
    {

    }

    private void UpdateBook()
    {
        if (_updateBookEvent != null)
        {
            _updateBookEvent(this, new EventArgs());
        }
    }

    void OnGUI()
    {
        
        
    }

    
}
