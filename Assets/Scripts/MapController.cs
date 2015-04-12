using UnityEngine;
using System.Runtime.InteropServices;

public class MapController : MonoBehaviour
{
    private bool mouseControled;
    private MouseOperations.MousePoint _cursorPosition;

	// Use this for initialization
	void Start ()
	{
	    Cursor.SetCursor(Config.Cursor, new Vector2(3, 1), CursorMode.ForceSoftware);
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
	        _cursorPosition = MouseOperations.GetCursorPosition();
	    }
	    else
	    {
	        _cursorPosition.X += (int) (Input.GetAxis("Horizontal")*Config.MapMouseEmulationSpeed);
	        _cursorPosition.Y -= (int) (Input.GetAxis("Vertical")*Config.MapMouseEmulationSpeed);

            MouseOperations.SetCursorPosition(_cursorPosition);
	    }

        if (Input.GetAxis("Fire1") != 0 || Input.GetAxis("Submit") != 0)
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp | MouseOperations.MouseEventFlags.LeftDown);

	}
}
