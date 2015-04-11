using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TownView : MonoBehaviour {

	public GameObject Town_Base { get; private set; }
	private GameObject Player;
	private List<Transform> ParallaxObjects;

	// Use this for initialization
	void Start () {
		Town_Base = GameObject.Find ("Town_Base");
		Player = GameObject.Find ("Player");
		//ParallaxObjects = GameObject.FindGameObjectsWithTag ("Parallax");
		ParallaxObjects = this.GetComponentsInChildren<Transform> ().ToList();
		ParallaxObjects.RemoveAt (0);
		for (int i = 0; i < ParallaxObjects.Count; i++)
			ParallaxObjects.ElementAt(i).gameObject.layer = LayerMask.NameToLayer("Parallax"+(i+1));
	}
	
	// Update is called once per frame
	void Update () {
		//foreach(var obj in ParallaxObjects)
		//	TranslateParallax(obj.gameObject);
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

	public float GetWidth(GameObject obj)
	{
		return obj.transform.localScale.x * obj.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
	}

	public int AmountOfParallax()
	{
		return ParallaxObjects.Count;
	}
}
