using System.Collections.Generic;
using UnityEngine;
using System.Collections;


/// <summary>
/// This is the main class for this game. This class will never be destroyed
/// </summary>
public class Game : MonoBehaviour {

    private List<Town> _towns = new List<Town>();

    public List<Town> GetTowns()
    {
        return _towns;
    }

    void Awake(){
        Debug.Log("The Game");
        DontDestroyOnLoad(this.gameObject);
        CreateTowns();
    }

    // Use this for initialization
	void Start () {

	    
	}
	
    private void CreateTowns()
    {
        _towns.Add(new Town("Town A")); 
        _towns.Add(new Town("Town B"));
        _towns.Add(new Town("Town C"));
    }

    
}
