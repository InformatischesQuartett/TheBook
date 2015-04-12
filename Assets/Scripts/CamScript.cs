using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CamScript : MonoBehaviour {

    public Color BgColor;
    public Texture CoatOfArms;

    private bool _showCoat;

    private Material mat;
    
	private List<GameObject> ParallaxCameras;
	private List<RenderTexture> ParallaxTextures;

	// Use this for initialization
	void Start () {
		ParallaxCameras = new List<GameObject>();
		ParallaxTextures = new List<RenderTexture>();
		mat = new Material (Shader.Find ("Unlit/Transparent"));

	    _showCoat = true;

		// Create cameras for parallax objects
		var townViewScript = GameObject.Find ("TownController").GetComponent<TownView>();

        var index = 1;
        while (LayerMask.NameToLayer("Parallax" + index) != -1) {
			GameObject newobj = new GameObject("autoCamera" + index, typeof(Camera));
			var cam = newobj.GetComponent<Camera>();

            var color = cam.backgroundColor;
            color.a = 0;
            cam.backgroundColor = color;

            if (index == 1)
                cam.backgroundColor = BgColor;

			cam.clearFlags = CameraClearFlags.SolidColor;
			cam.cullingMask = (1 << LayerMask.NameToLayer("Parallax"+index));
			
			RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 24, RenderTextureFormat.ARGB32);
			ParallaxTextures.Add(rt);
			cam.targetTexture = rt;
			
			cam.transform.parent = this.transform;
			cam.transform.localPosition = new Vector3();
			ParallaxCameras.Add (newobj);

            index++;
		}
	}

    void OnPostRender()
    {
        GL.Clear(true, true, Color.black);

        foreach (var tex in ParallaxTextures)
        {
            Graphics.Blit(tex, null as RenderTexture, mat);
        }
    }

    void OnGUI()
    {
        if (_showCoat)
        {
            var aspRatio = (float) CoatOfArms.width/CoatOfArms.height;

            var coatHeight = Screen.height*0.75f;
            var coatWidth = aspRatio*coatHeight;

            var coatLeft = Screen.width/2.0f - coatWidth/2.0f;
            var coatTop = Screen.height/2.0f - coatHeight/2.0f;

            GUI.DrawTexture(new Rect(coatLeft, coatTop, coatWidth, coatHeight), CoatOfArms);
        }
            
    }

    public void DisableCoat()
    {
        _showCoat = false;
    }


}
