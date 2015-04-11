using System;
using UnityEngine;
using System.Collections;

/**
 * This class represents a rule in the book.
 **/
public class Rule
{

    private String _rule;
    private bool _active;
   /**
    * Constructor
    **/
    Rule(String rule)
    {
        _rule = rule;
        _active = false;
    }

    /**
    * Getter Rule
    **/
    public String getRule()
    {
        return _rule;
    }

    /**
    * Setter State
    **/
    public void setActive(bool state)
    {
        _active = state;
    }
	
}
