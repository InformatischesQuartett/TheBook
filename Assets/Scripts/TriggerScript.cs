using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.BroadcastMessage("ShowBubble", true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        gameObject.BroadcastMessage("ShowBubble", false);
    }
}
