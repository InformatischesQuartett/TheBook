using UnityEngine;
using System.Collections;

public class TownView : MonoBehaviour {

	private GameObject Town_Base;
	private GameObject Player;
	private GameObject[] ParallaxObjects;

	// Use this for initialization
	void Start () {
		Town_Base = GameObject.Find ("Town_Base");
		Player = GameObject.Find ("Player");
		ParallaxObjects = GameObject.FindGameObjectsWithTag ("Parallax");
	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject obj in ParallaxObjects)
			TranslateParallax(obj);
	}

	void TranslateParallax(GameObject obj)
	{
		float width = GetWidth (obj);
		float baseWidth = GetWidth (Town_Base);
		float interval = (Player.transform.position.x / baseWidth) + 0.5f;
		float overflow = (width - baseWidth) / 2;
		float xPos = overflow - (interval * overflow * 2);
		obj.transform.position = new Vector2(xPos, obj.transform.position.y);
	}

	float GetWidth(GameObject obj)
	{
		return obj.transform.localScale.x * obj.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
	}
}
