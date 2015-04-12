using UnityEngine;
using System.Collections;

public class GUIMapScreenFunctions : MonoBehaviour {

    public void LoadClayton()
    {
        Application.LoadLevel("Town1");
    }

    public void LoadDesertville()
    {
        Application.LoadLevel("Town2");
    }

    public void LoadOrienta()
    {
        Application.LoadLevel("Town3");
    }
}
