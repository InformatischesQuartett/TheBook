using System;
using UnityEngine;
using System.Collections;
using System.Runtime.Remoting;

/**
 * This class represents a rule in the book.
 **/
public class Rule
{
    /**
     * Enum for the states of a ruleText. Rules are always undiscovered till the player finds them by talking with the towns ppl.
     * After that they will be set to proposed and will be added to the book as proposals.
     * If the player accepts them, they are active.
     * If he deletes them, they are deleted.
     **/
    enum RuleState
    {
        Undiscovered,
        Known,
        Active,
        Deleted
    }

    private readonly String _ruleText;
    private RuleState _state;


    public bool isActive
    {
        get
        {
            return (_state == RuleState.Active) ? true : false;
        }
        set
        {
            _state = RuleState.Active;
        }
    }

    public bool isDeleted
    {
        get
        {
            return (_state == RuleState.Deleted) ? true : false;
        }
        set
        {
            _state = RuleState.Deleted;
        }
    }

    public bool isKnown
    {
        get
        {
            return (_state == RuleState.Known) ? true : false;
        }
        set
        {
            _state = RuleState.Known;
        }
    }


    
   /**
    * Constructor
    **/
    public Rule(string ruletext)
    {
        _ruleText = ruletext;
        _state = RuleState.Undiscovered;
    }

    /**
    * Getter Rule
    **/
    public String GetRule()
    {
        return _ruleText;
    }
	
}
