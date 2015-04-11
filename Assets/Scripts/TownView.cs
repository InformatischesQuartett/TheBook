using UnityEngine;
using System.Collections;

public class TownView : MonoBehaviour {

	public GameObject Town_Base;
	public GameObject Town_FG;
	public GameObject Town_BG;
	public GameObject Player;

	// Use this for initialization
	void Start () {
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
		float interval = ((Player.transform.position.x) / width + 1) / 2;
		float xPos = (width - baseWidth)/2 + (interval * (width/2));
		obj.transform.position = new Vector2(xPos, obj.transform.position.y);
	}

	float GetWidth(GameObject obj)
	{
		return obj.transform.localScale.x * obj.GetComponent<SpriteRenderer>().sprite.bounds.extents.x;
	}
}
