using System;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class CharacterController : MonoBehaviour
{
    private float _speed;

    private bool _init;
    private bool _animState;

    private float _halfW;
    private float _startX;

	private GameObject _townController;
    private TownView _townScript;

    private Vector3 _townPos;
    private float _townWidth;

	// Use this for initialization
	void Start ()
	{
	    _speed = Config.CharacterWalkSpeed;

		_townController = GameObject.Find ("TownController");
        _townScript = _townController.GetComponent<TownView>();

        _init = false;
        _animState = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (!_init)
        {
            _townWidth = _townScript.GetWidth(_townScript.Town_Base);
            _townPos = _townScript.Town_Base.transform.position;

            var depthZ = Camera.main.WorldToScreenPoint(_townPos).z;
            _halfW = -Camera.main.ScreenToWorldPoint(new Vector3(0, 0, depthZ)).x;

            // move to left edge
            var vec = _townPos + _townWidth / 2 * Vector3.left;
            Camera.main.transform.position = new Vector3(vec.x, 0, 0);
            Camera.main.transform.position += Vector3.right * _halfW;
            
            // set player
            _startX = Camera.main.transform.position.x;

            var plPos = this.transform.position;
            this.transform.position = new Vector3(_startX - _halfW, plPos.y, plPos.z);

            // start animation
            this.GetComponent<Animator>().SetBool("Walk", true);
            _animState = true;

            _init = true;
        }

        if (_animState)
        {
            transform.Translate(0.8f * _speed * Time.deltaTime, 0, 0);

            if (transform.position.x >= _startX - _halfW/4.0f)
            {
                var plPos = transform.position;
                transform.position = new Vector3(_startX - _halfW/4.0f, plPos.y, plPos.z);

                if (Math.Abs(Input.GetAxis("Horizontal")) < 0.01f)
                    GetComponent<Animator>().SetBool("Walk", false);

                Camera.main.gameObject.GetComponent<BlurOptimized>().enabled = false;
                Camera.main.gameObject.GetComponent<CamScript>().DisableCoat();

                _animState = false;
            }

            return;
        }

        var camPos = Camera.main.transform.position;
		var leftBaseScreen = Camera.main.WorldToScreenPoint (_townPos + _townWidth / 2 * Vector3.left);
        var rightBaseScreen = Camera.main.WorldToScreenPoint(_townPos + _townWidth / 2 * Vector3.right);

        var allowWalk = (Input.GetAxis("Horizontal") < 0 && transform.position.x > _startX - _halfW/4.0f);
        allowWalk |= (Input.GetAxis("Horizontal") > 0 && rightBaseScreen.x > Screen.width);
        
        if (allowWalk)
        {
            this.transform.Translate(Input.GetAxis("Horizontal") * _speed * Time.deltaTime, 0, 0);
            this.GetComponent<Animator>().SetBool("Walk", Math.Abs(Input.GetAxis("Horizontal")) > 0.01f);

            var scale = this.transform.localScale.y;

            if (Input.GetAxis("Horizontal") < 0)
                this.transform.localScale = new Vector3(-scale, scale, scale);
            if (Input.GetAxis("Horizontal") > 0)
                this.transform.localScale = new Vector3(scale, scale, scale);

            if (transform.position.x > _startX)
                Camera.main.transform.position = new Vector3(transform.position.x, camPos.y, camPos.z);
        } else
            this.GetComponent<Animator>().SetBool("Walk", false);

	    if (Math.Abs(Input.GetAxis("Submit")) > 0.01f)
	    {
	        Debug.Log("Submit");
	    }

	    if (Math.Abs(Input.GetAxis("Cancel")) > 0.01f)
	    {
	        Debug.Log("Cancel");
	    }
	}
}
