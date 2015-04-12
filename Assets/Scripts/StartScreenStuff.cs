using UnityEngine;
using System.Collections;

public class StartScreenStuff : MonoBehaviour {

	// Use this for initialization
    void Start()
    {
        Cursor.SetCursor(Config.Cursor, new Vector2(3, 1), CursorMode.ForceSoftware);
    }
}
