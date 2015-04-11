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
     * Enum for the states of a rule. Rules are always undiscovered till the player finds them by talking with the towns ppl.
     * After that they will be set to proposed and will be added to the book as proposals.
     * If the player accepts them, they are active.
     * If he deletes them, they are deleted.
     **/
    enum RuleState
    {
        Undiscovered,
        Proposed,
        Active,
        Deleted
    }

    private readonly String _rule;
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

    public bool isProposed
    {
        get
        {
            return (_state == RuleState.Proposed) ? true : false;
        }
        set
        {
            _state = RuleState.Proposed;
        }
    }


    
   /**
    * Constructor
    **/
    Rule(String rule)
    {
        _rule = rule;
        _state = RuleState.Undiscovered;
    }

    /**
    * Getter Rule
    **/
    public String getRule()
    {
        return _rule;
    }
	
}
