using UnityEngine;
using System.Collections;

public class StartScreenStuff : MonoBehaviour {

	// Use this for initialization
    void Start()
    {
        Cursor.SetCursor(Config.Cursor, new Vector2(17, 9), CursorMode.Auto);
    }
}
