using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour
{
    private float speed;
	private GameObject camera;
	private GameObject townController;

	// Use this for initialization
	void Start ()
	{
	    speed = Config.CharacterWalkSpeed;
		camera = GameObject.Find ("Main Camera");
		townController = GameObject.Find ("TownController");
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

		positionCam ();
	}

	void positionCam()
	{
		var script = townController.GetComponent<TownView>();
		camera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -10);

		Vector3 ll = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
		Vector3 ur = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0));
		float camWidth = Mathf.Abs (ll.x - ur.x);

		if (ll.x < -script.GetWidth (script.Town_Base) / 2)
		{
			camera.transform.position = new Vector3((-script.GetWidth (script.Town_Base) / 2) + camWidth / 2, this.transform.position.y, -10);
		}
		if (ur.x > script.GetWidth (script.Town_Base) / 2)
		{
			camera.transform.position = new Vector3((script.GetWidth (script.Town_Base) / 2) - camWidth / 2, this.transform.position.y, -10);
		}
	}
}
