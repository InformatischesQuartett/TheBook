using UnityEditor;
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
    public GUIStyle ArrowLeftStyle;
    public GUIStyle SiegelStyle;
    public GUIStyle DeleteStyle;
    
    public Font theFont;

    private Vector2 bookSize;
    private Vector2 boxSize;
    private Vector2 textBGSize;
    private Vector2 iconSize;
    private Vector2 arrowSize;
    private Vector2 siegelSize;
    private Vector2 deleteSize;

    public float width;
    public float height;
    public float posX;
    public float posY;

    private int currentPage;

    //determines if the book is shown or not after clicking the book icon
    private bool _enableBook;

    //TODO: dynamic size regarding the actual number of total rules
    //private static int _ruleAmount = 6;
    //private bool[] showingBookPage = new bool[_ruleAmount];

    //reference on the book script
    private Book _book;


	// Use this for initialization
	void Start ()
	{
        //set book guistyle
	    BookStyle.normal.textColor = Color.black;
	    BookStyle.fontSize = 20;
	    BookStyle.font = theFont;
	    BookStyle.wordWrap = true;

        //load all images
	    //bookImage = (Texture2D)Resources.Load<Texture2D>("/Book/thebook-main_trim");

        _book = this.GetComponent<Book>();
	    currentPage = 0;
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

	    textBGSize.x = 0.35f*bookSize.x;
	    textBGSize.y = 0.42f*bookSize.y;

	    iconSize.x = 0.08f * (Screen.width);
        iconSize.y = 0.13f * (Screen.height);

	    arrowSize.x = 0.1f* bookSize.x;
	    arrowSize.y = 0.18f * bookSize.y;

	    siegelSize.x = 0.1f*bookSize.x;
	    siegelSize.y = 0.16f*bookSize.y;

	    deleteSize.x = 0.1f*bookSize.x;
	    deleteSize.y = 0.1f*bookSize.y;


	}

    private void ShowBook()
    {
        //book background tex
        GUI.DrawTexture(new Rect((Screen.width * 0.5f) - (bookSize.x / 2), (Screen.height * 0.5f) - (bookSize.y / 2), bookSize.x, bookSize.y), bookImage);
        //close book button
        if (GUI.Button(new Rect(Screen.width*0.7223f, Screen.height*0.11f, siegelSize.x, siegelSize.y), "", SiegelStyle))
        {
            _enableBook = !_enableBook;
        }

            //group for the whole book area
            GUI.BeginGroup(new Rect((Screen.width * 0.5f) - (bookSize.x / 2), (Screen.height * 0.5f) - (bookSize.y / 2), bookSize.x, bookSize.y));
             
                //right arrow button        
                if (currentPage + 2 < Config.Beliefs.Count)
                {
                    if (GUI.Button(new Rect(bookSize.x * 0.836f, bookSize.y * 0.67f, arrowSize.x, arrowSize.y), "", ArrowRightStyle))
                        {
                            currentPage+=2;
                        }
                }

                //left arrow button
                if (currentPage > 0)
                {
                    if (GUI.Button(new Rect(bookSize.x*0.05f, bookSize.y*0.67f, arrowSize.x, arrowSize.y), "", ArrowLeftStyle) )
                    {
                        currentPage -= 2;
                    }
                }
       
                //group for left page
                GUI.BeginGroup(new Rect(bookSize.x * 0.08f, bookSize.y * 0.08f, boxSize.x, boxSize.y));

                    //text background left
                     GUI.DrawTexture(new Rect(bookSize.x * 0.006f, bookSize.y*0.04f, textBGSize.x, textBGSize.y), textBackground);
                    //delete Button left
                     if (GUI.Button(new Rect(0, bookSize.y * 0.06f, deleteSize.x, deleteSize.y), "", DeleteStyle))
                    {
                        
                    }
                   
                    //textfield left
                    GUI.TextArea(new Rect(bookSize.x * 0.03f, bookSize.y * 0.18f, boxSize.x * 0.76f, boxSize.y * 0.47f), Config.Beliefs[currentPage].rule, BookStyle);
                GUI.EndGroup();

                //Group for right page
                GUI.BeginGroup(new Rect(bookSize.x * 0.506f, bookSize.y * 0.25f, boxSize.x, boxSize.y * 0.75f));
                    GUI.Box(new Rect(0, 0, boxSize.x, boxSize.y * 0.75f), Config.Beliefs[currentPage+1].rule, BookStyle);
                GUI.EndGroup();

            GUI.EndGroup();
        


    }

   
    void OnGUI () {
       // Debug.Log(Application.loadedLevel);
        if (Application.loadedLevel != 0)
        {
            if (GUI.Button(new Rect(Screen.width - (iconSize.x*1.25f), (iconSize.y*0.18f), iconSize.x, iconSize.y), "",
                IconStyle))
            {
                _enableBook = !_enableBook;

            }

            if (_enableBook)
            {
                ShowBook();
            }
        }
    }
  
}
