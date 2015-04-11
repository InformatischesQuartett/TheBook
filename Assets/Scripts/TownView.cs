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
		Town_Base = GameObject.FindGameObjectWithTag ("Base");
        var distToCam = Camera.main.transform.position.z - Town_Base.transform.position.z;

		Player = GameObject.Find ("Player");

		ParallaxObjects = this.GetComponentsInChildren<Transform> ().ToList();
		ParallaxObjects.RemoveAt (0);

        for (int i = 0; i < ParallaxObjects.Count; i++)
        {
            var go = ParallaxObjects.ElementAt(i).gameObject;

            var tmpDist = Camera.main.transform.position.z - go.transform.position.z;
            var diff = tmpDist / distToCam;

            go.transform.localScale *= diff; 
        }

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
