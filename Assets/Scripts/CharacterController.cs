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
        var script = townController.GetComponent<TownView>();
		var camPos = camera.transform.position;
		var newPos = new Vector3 (this.transform.position.x, camera.transform.position.y, camPos.z);

		var priorZ = Camera.main.WorldToScreenPoint (script.Town_Base.transform.position).z;
		var leftBaseScreen = Camera.main.WorldToScreenPoint (script.Town_Base.transform.position + script.GetWidth (script.Town_Base) / 2 * Vector3.left);
		var rightBaseScreen = Camera.main.WorldToScreenPoint (script.Town_Base.transform.position + script.GetWidth (script.Town_Base) / 2 * Vector3.right);
		var camWorldWidth = Camera.main.ScreenToWorldPoint (new Vector3(leftBaseScreen.x, leftBaseScreen.y, 0));

        var allowWalk = (Input.GetAxis("Horizontal") < 0 && leftBaseScreen.x < 0);
        allowWalk |= (Input.GetAxis("Horizontal") > 0 && rightBaseScreen.x > Screen.width);
        
        if (allowWalk)
        {
            this.transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);

            if (Input.GetAxis("Horizontal") != 0)
                this.GetComponent<Animator>().SetBool("Walk", true);
            else
                this.GetComponent<Animator>().SetBool("Walk", false);

            var scale = this.transform.localScale.y;

            if (Input.GetAxis("Horizontal") < 0)
                this.transform.localScale = new Vector3(-scale, scale, scale);
            if (Input.GetAxis("Horizontal") > 0)
                this.transform.localScale = new Vector3(scale, scale, scale);

            camera.transform.position = new Vector3(this.transform.position.x, camera.transform.position.y, camPos.z);
        } else
            this.GetComponent<Animator>().SetBool("Walk", false);

	    if (Input.GetAxis("Submit") != 0)
	    {
	        Debug.Log("Submit");
	    }

	    if (Input.GetAxis("Cancel") != 0)
	    {
	        Debug.Log("Cancel");
	    }
	}
}
