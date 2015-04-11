using UnityEngine;
using System.Collections;

public class MapController : MonoBehaviour
{
    private Texture2D _cursorTexture;

	// Use this for initialization
	void Start ()
	{
        _cursorTexture = (Texture2D)Resources.Load("dummys/target");
        Cursor.SetCursor(_cursorTexture, new Vector2(100,100), CursorMode.Auto);
	}
	
	// Update is called once per frame
	void Update ()
	{

	}
}
