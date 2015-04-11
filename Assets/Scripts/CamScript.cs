using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CamScript : MonoBehaviour {

    public Material mat;
	private List<GameObject> ParallaxCameras;
	private List<RenderTexture> ParallaxTextures;

	// Use this for initialization
	void Start () {
		ParallaxCameras = new List<GameObject>();
		ParallaxTextures = new List<RenderTexture>();
		mat = new Material (Shader.Find ("Unlit/Transparent"));

		// Create cameras for parallax objects
		var TownViewScript = GameObject.Find ("TownController").GetComponent<TownView>();

		for (uint i = 1; i <= TownViewScript.AmountOfParallax(); i++){
			GameObject newobj = new GameObject("autoCamera" + i, typeof(Camera));
			var cam = newobj.GetComponent<Camera>();
			var color = cam.backgroundColor;
			color.a = 0;
			cam.backgroundColor = color;
			cam.orthographic = true;
			cam.clearFlags = CameraClearFlags.SolidColor;
			cam.cullingMask = (1 << LayerMask.NameToLayer("Parallax"+i));
			
			RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 24, RenderTextureFormat.ARGB32);
			ParallaxTextures.Add(rt);
			cam.targetTexture = rt;
			
			cam.transform.parent = this.transform;
			cam.transform.localPosition = new Vector3();
			ParallaxCameras.Add (newobj);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnPostRender() {
        GL.Clear(true, true, Color.black);

		foreach (var tex in ParallaxTextures) {
			Graphics.Blit (tex, null as RenderTexture, mat);
		}

       // RenderTexture.active = backSceneRT;
       // GL.Clear(true, true, Color.black);

      /*  RenderTexture.active = mainSceneRT;
        GL.Clear(true, true, Color.black);
        */
        RenderTexture.active = null;
    }
}
