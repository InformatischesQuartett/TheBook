using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Book : MonoBehaviour {

    /*all rules that are in the book*/
    public  List<Rule> _ruleList = new List<Rule>();
    public List<Rule> _activeRules = new List<Rule>();
    private List<Rule> _knownRules = new List<Rule>();

    private event EventHandler _updateBookEvent;
	
    // Use this for initialization
	void Start ()
	{
	    
	    InitRuleList();


	    foreach (var town in Game.GetTowns())
	    {
	        _updateBookEvent += town.OnUpdateBook;
	    }
        
	}

    public List<Rule> GetActiveRules()
    {
        return _activeRules;
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
        //adding and activating the rule of the rules
        _ruleList.Add(Game.MasterRule);
        Game.MasterRule.isActive = true;
        foreach (var belief in Game.Config.Beliefs)
        {
            _ruleList.Add(new Rule(belief.rule, belief.beliefName));
        }
        UpdateBook();
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

    /// <summary>
    /// Activate a rule, which will be written in the book immediately
    /// </summary>
    /// <param name="key"></param>
    public void WriteRule(Rule ruleActivate)
    {
        ruleActivate.isActive = true;
        UpdateBook();
    }

    private void UpdateBook()
    {
        UpdateLists();
        if (_updateBookEvent != null)
        {
            _updateBookEvent(this, new EventArgs());
        }
    }   
}
