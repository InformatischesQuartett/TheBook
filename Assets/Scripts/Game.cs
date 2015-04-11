using System.Collections.Generic;
using UnityEngine;
using System.Collections;


/// <summary>
/// This is the main class for this game. This class will never be destroyed
/// </summary>
public class Game : MonoBehaviour {

    private List<Town> Towns { get; set; }

    void Awake(){
        Debug.Log("The Game");
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
	void Start () {
	    Towns = new List<Town>();
	    CreateTowns();
	}
	
    private void CreateTowns()
    {
        Towns.Add(new Town("Town A")); 
        Towns.Add(new Town("Town B"));
        Towns.Add(new Town("Town C"));
    }
}
