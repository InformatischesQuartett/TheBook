using UnityEngine;
using System.Collections;

public class CamScript : MonoBehaviour {

    public Material mat;
    public RenderTexture backSceneRT;
    public RenderTexture mainSceneRT;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnPostRender() {
        GL.Clear(true, true, Color.black);

       Graphics.Blit(backSceneRT, null as RenderTexture, mat);
        Graphics.Blit(mainSceneRT, null as RenderTexture, mat);

       // RenderTexture.active = backSceneRT;
       // GL.Clear(true, true, Color.black);

      /*  RenderTexture.active = mainSceneRT;
        GL.Clear(true, true, Color.black);
        */
        RenderTexture.active = null;
    }
}
