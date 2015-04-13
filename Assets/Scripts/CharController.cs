using System;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class CharController : MonoBehaviour
{
    private enum PlayerState
    {
        Init,
        Intro,
        Expl,
        Talk,
        Stage,
        Speech
    }

    private float _speed;

    private PlayerState _playerState;

    private float _halfW;
    private float _startX;

    private GameObject _townController;
    private TownView _townScript;

    private Vector3 _townPos;
    private float _townWidth;

    private GameObject _stageObj;

    private void Start()
    {
        _speed = Config.CharacterWalkSpeed;

        _townController = GameObject.Find("TownController");
        _townScript = _townController.GetComponent<TownView>();

        _playerState = PlayerState.Init;
    }

    private void Update()
    {
        if (_playerState == PlayerState.Init)
        {
            _townWidth = _townScript.GetWidth(_townScript.TownBase);
            _townPos = _townScript.TownBase.transform.position;

            var depthZ = Camera.main.WorldToScreenPoint(_townPos).z;
            _halfW = -Camera.main.ScreenToWorldPoint(new Vector3(0, 0, depthZ)).x;

            // move cam to left edge
            var vec = _townPos + _townWidth/2*Vector3.left;
            Camera.main.transform.position = new Vector3(vec.x, 0, 0);
            Camera.main.transform.position += Vector3.right*_halfW;

            // set player
            _startX = Camera.main.transform.position.x;

            var plPos = this.transform.position;
            this.transform.position = new Vector3(_startX - _halfW, plPos.y, plPos.z);

            // start animation
            GetComponent<Animator>().SetBool("Walk", true);
            _playerState = PlayerState.Intro;
        }

        if (_playerState == PlayerState.Intro)
        {
            this.transform.Translate(0.8f*_speed*Time.deltaTime, 0, 0);
            if (!(this.transform.position.x >= _startX - _halfW/4.0f)) return;

            var plPos = this.transform.position;
            this.transform.position = new Vector3(_startX - _halfW/4.0f, plPos.y, plPos.z);

            if (Math.Abs(Input.GetAxis("Horizontal")) < 0.01f)
                this.GetComponent<Animator>().SetBool("Walk", false);

            Camera.main.gameObject.GetComponent<BlurOptimized>().enabled = false;
            Camera.main.gameObject.GetComponent<CamScript>().DisableCoat();

            _playerState = PlayerState.Expl;

            return;
        }

        var camPos = Camera.main.transform.position;
        var rightBaseScreen = Camera.main.WorldToScreenPoint(_townPos + _townWidth/2*Vector3.right);

        var allowWalk = (Input.GetAxis("Horizontal") < 0 && transform.position.x > _startX - _halfW/4.0f);
        allowWalk |= (Input.GetAxis("Horizontal") > 0 && rightBaseScreen.x > Screen.width);

        if (allowWalk)
        {
            var fastWalk = 1;
            if (Input.GetKey(KeyCode.LeftShift))
                fastWalk = 3;

            this.transform.Translate(Input.GetAxis("Horizontal")*_speed*fastWalk*Time.deltaTime, 0, 0);
            this.GetComponent<Animator>().SetBool("Walk", Math.Abs(Input.GetAxis("Horizontal")) > 0.01f);
            this.GetComponent<Animator>().SetBool("Talk", false);

            var scale = this.transform.localScale.y;

            if (Input.GetAxis("Horizontal") < 0)
                this.transform.localScale = new Vector3(-scale, scale, scale);
            if (Input.GetAxis("Horizontal") > 0)
                this.transform.localScale = new Vector3(scale, scale, scale);

            if (transform.position.x > _startX)
            {
                Camera.main.transform.position = new Vector3(transform.position.x, camPos.y, 0);

                // zoom out
                if (_playerState == PlayerState.Stage)
                {
                    var stCol = _stageObj.GetComponent<BoxCollider2D>();

                    var stMin = _stageObj.transform.position.x - stCol.size.x/2.0f;
                    var stMax = _stageObj.transform.position.x + stCol.size.x/2.0f;
                    var stWidth = stMax - stMin;

                    var diffFac = 1 - (stMax - this.transform.position.x) / stWidth;
                    diffFac = Mathf.Clamp(diffFac, 0f, 1f);

                    var maxZoom = Camera.main.GetComponent<CamScript>().StageZoom;
                    Camera.main.transform.Translate(0, 0, diffFac * maxZoom);
                }

                if (_playerState == PlayerState.Speech)
                {
                    var maxZoom = Camera.main.GetComponent<CamScript>().StageZoom;
                    Camera.main.transform.position = new Vector3(camPos.x, camPos.y, maxZoom);

                    this.GetComponent<Animator>().SetBool("Walk", false);
                    this.GetComponent<Animator>().SetBool("Talk", true);
                }
            }
        }
        else
            this.GetComponent<Animator>().SetBool("Walk", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Stage")
        {
            _stageObj = other.gameObject;
            _playerState = PlayerState.Stage;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "Stage") return;

        var plPos = this.transform.position.x;
        var sgPos = other.transform.position.x;

        _playerState = plPos > sgPos ? PlayerState.Speech : PlayerState.Expl;
    }
}