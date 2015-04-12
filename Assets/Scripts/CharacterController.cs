using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour
{
    private float speed;
    private bool init;

	private GameObject camera;
	private GameObject townController;
    private TownView townScript;

    private Vector3 townPos;
    private float townWidth;

	// Use this for initialization
	void Start ()
	{
	    speed = Config.CharacterWalkSpeed;
		camera = GameObject.Find ("Main Camera");

		townController = GameObject.Find ("TownController");
        townScript = townController.GetComponent<TownView>();

        init = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (!init)
        {
            townWidth = townScript.GetWidth(townScript.Town_Base);
            townPos = townScript.Town_Base.transform.position;

            var depthZ = Camera.main.WorldToScreenPoint(townPos).z;
            var halfW = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, depthZ)).x;

            // move to left edge
            var vec = townPos + townWidth / 2 * Vector3.left;
            camera.transform.position = new Vector3(vec.x, 0, 0);
            camera.transform.position += Vector3.left * halfW;
            
            // set player
            var plPos = this.transform.position;
            this.transform.position = new Vector3(camera.transform.position.x, plPos.y, plPos.z);

            init = true;
        }
            

		var camPos = camera.transform.position;
		var newPos = new Vector3 (this.transform.position.x, camera.transform.position.y, camPos.z);

		var priorZ = Camera.main.WorldToScreenPoint (townPos).z;
		var leftBaseScreen = Camera.main.WorldToScreenPoint (townPos + townWidth / 2 * Vector3.left);
        var rightBaseScreen = Camera.main.WorldToScreenPoint(townPos + townWidth / 2 * Vector3.right);
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
