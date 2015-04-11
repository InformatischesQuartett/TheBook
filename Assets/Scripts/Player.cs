using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{


    private Book _book;
	// Use this for initialization
	void Start ()
	{
	    _book = this.GetComponent<Book>();
	}
	
	// Update is called once per frame
	void Update () {
	
        if(Input.GetKeyUp(KeyCode.E))
	    {
            //Dialog
            //wir wissen über was wir reden
            //und dann scheriben wir den ensprechenen Rule in die liste

	       GetBeliefFromNpc();
	    }
	
	}

    private void GetBeliefFromNpc()
    {
        //NPC.dialog.Bellief
        Rule dummyRule = new Rule("There shall be no other food than fruits - protect all living creatures");
        _book.AddNewRule(dummyRule);
    }

    private void OnCollisionEnter()
    {

    }
}
