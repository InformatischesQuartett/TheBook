using UnityEngine;
using System.Linq;

public class TownView : MonoBehaviour {

	internal GameObject TownBase { get; private set; }
	private Transform[] _parallaxObjects;

	void Start () {
		TownBase = GameObject.FindGameObjectWithTag ("Base");
		var townPos = TownBase.transform.position;

		// calc visible width of base layer
        var boundL = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, townPos.z));
        var boundR = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, townPos.z));
		var wBaseVis = boundR.x - boundL.x;

		// iterate through all layer objects
		_parallaxObjects = GetComponentsInChildren<Transform>();

		foreach (var parObj in _parallaxObjects.Select(obj => obj.gameObject))	
        {
			if (parObj.tag != "Base" && parObj.tag != "Parallax")
			{
				// set layers "layer" setting to his parent's value
				parObj.layer = parObj.transform.parent.gameObject.layer;
				
				continue;
			}

			// calc necessary width for layer
            var wLayer = GetWidth(parObj);
            var dpFac = parObj.transform.position.z / townPos.z;
			var sizeFac = 1 + ((dpFac - 1) * wBaseVis) / wLayer;

            parObj.transform.localScale = new Vector3(sizeFac, sizeFac, 1);
	    }
	}

	public float GetWidth(GameObject obj)
	{
		return obj.transform.localScale.x * obj.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
	}

	public int AmountOfParallax()
	{
		return _parallaxObjects.Length;
	}
}