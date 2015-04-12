﻿using System.Collections.Generic;
using UnityEngine;
using System.Collections;


/// <summary>
/// This is the main class for this game. This class will never be destroyed
/// </summary>
public static class Game {

    private static List<Town> _towns = new List<Town>();
    public static Rule MasterRule = new Rule("Thou shalt not kill.", "MasterRule");

    public static List<Town> GetTowns()
    {
        return _towns;
    }

    static Game()
    {
        Debug.Log("The Game");
        _towns.Add(new Town("Town A"));
        _towns.Add(new Town("Town B"));
        _towns.Add(new Town("Town C"));

    }
}
