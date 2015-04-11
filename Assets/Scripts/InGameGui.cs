using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InGameGui : MonoBehaviour
{

    public Texture2D bookImage;
    public Texture2D textBackground;
    public GUIStyle BookStyle;
    public GUISkin skin;
    public Font theFont;

    private Vector2 bookSize;
    private Vector2 boxSize;

	// Use this for initialization
	void Start ()
	{
	    BookStyle.normal.textColor = Color.black;
	    BookStyle.fontSize = 20;
	    BookStyle.font = theFont;
	    BookStyle.wordWrap = true;
	}
	
	// Update is called once per frame
	void Update ()
	{

        BookStyle.fontSize = (int)(Screen.width * 0.02f);

        bookSize.x = 0.8f * (Screen.width);
        bookSize.y = 0.88f * (Screen.height);

        boxSize.x = 0.8f * bookSize.x/2;
        boxSize.y = 0.7f * bookSize.y;


	}

    private void ShowBook()
    {
        GUI.skin = skin;

        GUI.DrawTexture(new Rect((Screen.width * 0.5f) - (bookSize.x / 2), (Screen.height * 0.5f) - (bookSize.y / 2), bookSize.x, bookSize.y), bookImage);
        GUI.BeginGroup(new Rect((Screen.width * 0.5f) - (bookSize.x / 2), (Screen.height * 0.5f) - (bookSize.y / 2), bookSize.x, bookSize.y));

            //left page
            GUI.BeginGroup(new Rect(bookSize.x * 0.08f, bookSize.y * 0.08f, boxSize.x, boxSize.y));
            //GUI.Box(new Rect(bookSize.x * 0.08f, bookSize.y*0.08f, boxSize.x, boxSize.y), "test");
            //GUI.Box(new Rect(0, 0, boxSize.x, boxSize.y), "FOOOOOOOOOO", BookStyle);
            // GUILayout.TextArea(Config.Beliefs[0].rule, (int)boxSize.x, BookStyle);
        
            GUI.TextArea(new Rect(0,0, boxSize.x, boxSize.y), Config.Beliefs[0].rule, BookStyle);
            GUI.EndGroup();

            //right page
            GUI.BeginGroup(new Rect(bookSize.x * 0.506f, bookSize.y * 0.25f, boxSize.x, boxSize.y * 0.75f));
            //GUI.Box(new Rect(bookSize.x * 0.08f, bookSize.y*0.08f, boxSize.x, boxSize.y), "test");
            GUI.Box(new Rect(0, 0, boxSize.x, boxSize.y * 0.75f), "BAAAAAAAAAAAAAAR", BookStyle);
            GUI.EndGroup();

        GUI.EndGroup();

    }


    void OnGUI () {
        ShowBook();
    }
  
}
