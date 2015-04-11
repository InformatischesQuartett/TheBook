using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Book : MonoBehaviour {

    /*all rules that are in the book*/
    private List<Rule> _ruleList = new List<Rule>();
    private List<Rule> _activeRules = new List<Rule>();
    private List<Rule> _knownRules = new List<Rule>();
    private Game _game;
    private event EventHandler _updateBookEvent;
	
    // Use this for initialization
	void Start ()
	{
	    _game = GameObject.Find("Game").GetComponent<Game>();
	    InitRuleList();


	    foreach (var town in _game.GetTowns())
	    {
	        _updateBookEvent += town.OnUpdateBook;
	    }
        
	}

    /// <summary>
    /// Is called whenever a new rule is added, deleted or discovered
    /// </summary>
    private void UpdateLists()
    {
        _knownRules.Clear();
        _activeRules.Clear();
        foreach (var rule in _ruleList)
        {
            //known
            if (rule.isKnown)
            {
                _knownRules.Add(rule);
            }
            //active
            if (rule.isActive)
            {
                _activeRules.Add(rule);
            }
        }
    }

    private void InitRuleList()
    {
        foreach (var belief in Config.Beliefs)
        {
            _ruleList.Add(new Rule(belief.rule));
        }
    }

    // Update is called once per frame
	void Update () 
    {
	    if (Input.GetKeyUp("space"))
	    {
	        foreach (var rule in _ruleList)
	        {
	            //Debug.Log(rule.GetRule());
	        }
	    }
    }


    /// <summary>
    /// Set Rule to known rule
    /// </summary>
    public void AddNewRule(Rule rule)
    {
        foreach (var knownRule in _knownRules)
        {
            if (knownRule.GetRule() == rule.GetRule())
            {
                return;
            }
        }

        foreach (var activeRule in _activeRules)
        {
            if (activeRule.GetRule() == rule.GetRule())
            {
                return;
            }
        }

        foreach (var ruleList in _ruleList)
        {
            if (ruleList.GetRule() == rule.GetRule())
            {
                ruleList.isKnown = true;
            }
        }

        UpdateBook();
    }

    private void WriteRule(String key)
    {
        
    }

    private void UpdateBook()
    {
        UpdateLists();
        if (_updateBookEvent != null)
        {
            _updateBookEvent(this, new EventArgs());
        }
    }

    void OnGUI()
    {
        
        
    }

    
}
