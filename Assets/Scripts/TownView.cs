using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class TownView : MonoBehaviour {

	internal GameObject TownBase { get; private set; }
	private List<Transform> _parallaxObjects;

	// Use this for initialization
	void Start () {
		TownBase = GameObject.FindGameObjectWithTag ("Base");

        var townWidth = GetWidth(TownBase);
        var townPos = TownBase.transform.position;

	    var leftBase = townPos + townWidth/2*Vector3.left;
        var depthZ = Camera.main.WorldToScreenPoint(townPos).z;
        var halfW = -Camera.main.ScreenToWorldPoint(new Vector3(0, 0, depthZ)).x;

        // move to left edge
        var vec = townPos + townWidth / 2 * Vector3.left;
        Camera.main.transform.position = new Vector3(vec.x, 0, 0);
        Camera.main.transform.position += Vector3.right * halfW;

		_parallaxObjects = this.GetComponentsInChildren<Transform> ().ToList();
		_parallaxObjects.RemoveAt (0);

	    for (int i = 0; i < _parallaxObjects.Count; i++)
	    {
	        var go = _parallaxObjects.ElementAt(i).gameObject;

	        var priorVec = Camera.main.WorldToScreenPoint(go.transform.position);
	        var leftEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, priorVec.y, priorVec.z));
	        var sizeFact = leftEdge.x/leftBase.x;

	        go.transform.localScale = new Vector3(sizeFact, sizeFact, sizeFact);
	    }

	    // set camera back to center
        Camera.main.transform.position = new Vector3(0, 0, 0);
	}

	public float GetWidth(GameObject obj)
	{
		return obj.transform.localScale.x * obj.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
	}

	public int AmountOfParallax()
	{
		return _parallaxObjects.Count;
	}
}
