using UnityEngine;
using System.Runtime.InteropServices;

public class MapController : MonoBehaviour
{
    private Texture2D _cursorTexture;
    private bool mouseControled;
    private Vector2 _cursorPosition;

    [DllImport("user32.dll")]
    public static extern bool SetCursorPos(int X, int Y);
    [DllImport("user32.dll")]
    public static extern bool GetCursorPos(out int X, out int Y);

	// Use this for initialization
	void Start ()
	{
        _cursorTexture = (Texture2D)Resources.Load("dummys/target");
        Cursor.SetCursor(_cursorTexture, new Vector2(100,100), CursorMode.Auto);
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
	    {
	        mouseControled = true;
	    }
        else if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            mouseControled = false;
        }

	    if (mouseControled)
	    {
	        int x, y;
	        GetCursorPos(out x, out y);
	        _cursorPosition.x = x;
	        _cursorPosition.y = y;
	    }
	    else
	    {
	        _cursorPosition.x += Input.GetAxis("Horizontal")*Config.MapMouseEmulationSpeed;
	        _cursorPosition.y -= Input.GetAxis("Vertical")*Config.MapMouseEmulationSpeed;
	        SetCursorPos((int) _cursorPosition.x, (int) _cursorPosition.y);
	    }

        Debug.Log(_cursorPosition);
	}
}
