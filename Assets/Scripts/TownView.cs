using UnityEngine;
using System.Collections;

public class TownView : MonoBehaviour {

	private GameObject Town_Base;
	private GameObject Town_FG;
	private GameObject Town_BG;
	private GameObject Player;

	// Use this for initialization
	void Start () {
		Town_Base = GameObject.Find ("Town_Base");
		Town_FG = GameObject.Find ("Town_Front");
		Town_BG = GameObject.Find ("Town_Back");
		Player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Town_FG != null)
			TranslateParallax(Town_FG);
		if (Town_BG != null)
			TranslateParallax(Town_BG);
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
