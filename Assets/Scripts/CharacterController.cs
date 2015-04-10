using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour
{

    private float speed;

	// Use this for initialization
	void Start ()
	{
	    speed = Config.CharacterWalkSpeed;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    this.transform.Translate(Input.GetAxis("Horizontal") * speed, 0, 0);

	    if (Input.GetAxis("Submit") != 0)
	    {
	        Debug.Log("Submit");
	    }
	    if (Input.GetAxis("Cancel") != 0)
	    {
	        Debug.Log("Cancel");
	    }
        Debug.Log(Input.GetAxis("Mouse X"));
	}
}
