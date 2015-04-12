using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InGameGui : MonoBehaviour
{

    public Texture2D bookImage;
    public Texture2D textBackground;
    public Texture2D bookIcon;
    public Texture2D arrowRight;

    public GUIStyle BookStyle;
    public GUIStyle IconStyle;
    public GUIStyle ArrowRightStyle;
    public GUISkin skin;
    public Font theFont;

    private Vector2 bookSize;
    private Vector2 boxSize;
    private Vector2 iconSize;
    private Vector2 arrowSize;

    public float width;
    public float height;
    public float posX;
    public float posY;

    //determines if the book is shown or not after clicking the book icon
    private bool _enableBook;

    //TODO: dynamic size regarding the actual number of total rules
    private static int _ruleAmount = 6;
    private bool[] showingBookPage = new bool[_ruleAmount];

    //reference on the book script
    private Book _book;


	// Use this for initialization
	void Start ()
	{
	    BookStyle.normal.textColor = Color.black;
	    BookStyle.fontSize = 20;
	    BookStyle.font = theFont;
	    BookStyle.wordWrap = true;

        _book = this.GetComponent<Book>();

	    _enableBook = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
        

        BookStyle.fontSize = (int)(Screen.width * 0.02f);

        bookSize.x = 0.8f * (Screen.width);
        bookSize.y = 0.88f * (Screen.height);

        boxSize.x = 0.8f * bookSize.x/2;
        boxSize.y = 0.7f * bookSize.y;

	    iconSize.x = 0.08f * (Screen.width);
        iconSize.y = 0.13f * (Screen.height);

	    arrowSize.x = 0.1f* bookSize.x;
	    arrowSize.y = 0.18f * bookSize.y;


	}

    private void ShowBook()
    {
        GUI.skin = skin;

        setAllPagesToFalse(0);
        //enabeling first book page
        showingBookPage[0] = true;

        GUI.DrawTexture(new Rect((Screen.width * 0.5f) - (bookSize.x / 2), (Screen.height * 0.5f) - (bookSize.y / 2), bookSize.x, bookSize.y), bookImage);


        if (showingBookPage[0])
        {
            GUI.BeginGroup(new Rect((Screen.width * 0.5f) - (bookSize.x / 2), (Screen.height * 0.5f) - (bookSize.y / 2), bookSize.x, bookSize.y));
                if (GUI.Button(new Rect(bookSize.x * 0.836f, bookSize.y * 0.67f, arrowSize.x, arrowSize.y), "", ArrowRightStyle))
                    {
                        setAllPagesToFalse(1);
                        showingBookPage[1] = true;
                    }
                //left page
                GUI.BeginGroup(new Rect(bookSize.x * 0.08f, bookSize.y * 0.08f, boxSize.x, boxSize.y));
                    //GUI.Box(new Rect(bookSize.x * 0.08f, bookSize.y*0.08f, boxSize.x, boxSize.y), "test");
                    //GUI.Box(new Rect(0, 0, boxSize.x, boxSize.y), "FOOOOOOOOOO", BookStyle);
                    // GUILayout.TextArea(Config.Beliefs[0].rule, (int)boxSize.x, BookStyle);

                    GUI.TextArea(new Rect(0, 0, boxSize.x, boxSize.y), Config.Beliefs[0].rule, BookStyle);
                GUI.EndGroup();

                //right page
                GUI.BeginGroup(new Rect(bookSize.x * 0.506f, bookSize.y * 0.25f, boxSize.x, boxSize.y * 0.75f));
                    //GUI.Box(new Rect(bookSize.x * 0.08f, bookSize.y*0.08f, boxSize.x, boxSize.y), "test");
                    GUI.Box(new Rect(0, 0, boxSize.x, boxSize.y * 0.75f), "BAAAAAAAAAAAAAAR", BookStyle);
                GUI.EndGroup();

            GUI.EndGroup();
        }
        

    }

    /// <summary>
    /// Sets all param to false except the number that is given as an argument.
    /// </summary>
    /// <param name="except"></param>
    void setAllPagesToFalse(int except)
    {
        for (int i = 0; i < showingBookPage.Length; i++)
        {
            if (i != except)
            {
                showingBookPage[i] = false;
            }
            
        }
    }

    void OnGUI () {
        
        if (GUI.Button(new Rect(Screen.width - (iconSize.x * 1.25f), (iconSize.y * 0.18f ), iconSize.x, iconSize.y), "", IconStyle))
        {
            _enableBook = !_enableBook;
        }

        if (_enableBook)
        {
            ShowBook();
        }
        
    }
  
}
