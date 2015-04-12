using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    private GameObject _afflictionClayton;
    private GameObject _afflictionDesertville;
    private GameObject _afflictionOrienta;

    public Sprite _goodSprite;
    public Sprite _neutralSprite;
    public Sprite _badSprite;
    public Sprite _unknownSprite;


    private MouseOperations.MousePoint _cursorPosition;
    private bool mouseControlled;
    // Use this for initialization

    private void Start()
    {
        Cursor.SetCursor(Config.Cursor, new Vector2(3, 1), CursorMode.ForceSoftware);
        
        _afflictionClayton = GameObject.Find("Clayton/Affliction");
        _afflictionDesertville = GameObject.Find("desertville/Affliction");
        _afflictionOrienta = GameObject.Find("Orienta/Affliction");

        UpdateAffliction();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            mouseControlled = true;
        }
        else if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            mouseControlled = false;
        }

        if (mouseControlled)
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

    private void UpdateAffliction()
    {
        // Hardcoded foo
        Debug.Log(Game.GetTowns()[0].Name);

        foreach (var town in Game.GetTowns())
        {
            if (town.Name == "Clayton")
            {
                _afflictionClayton.GetComponent<Image>().sprite = GetAfflictionSprite(town.HappinessRate);
            }
            else if (town.Name == "Desertville")
            {
                _afflictionDesertville.GetComponent<Image>().sprite = GetAfflictionSprite(town.HappinessRate);
            }
            else if (town.Name == "Orienta")
            {
                _afflictionOrienta.GetComponent<Image>().sprite = GetAfflictionSprite(town.HappinessRate);
            }
        }
    }

    private Sprite GetAfflictionSprite(float happiness)
    {
        if (happiness == -1)
        {
            return _unknownSprite;
        }
        else if (happiness >= 0 && happiness <= 0.3f)
        {
            return _badSprite;
        }
        else if (happiness > 0.3f && happiness <= 0.7)
        {
            return _neutralSprite;
        }
        else if (happiness > 0.7f && happiness <= 1)
        {
            return _goodSprite;
        }
        return _unknownSprite;
    }
}