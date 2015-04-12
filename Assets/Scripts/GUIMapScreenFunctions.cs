using UnityEngine;
using System.Collections;

public class GUIMapScreenFunctions : MonoBehaviour {

    public void LoadClayton()
    {
        Application.LoadLevel("Town1");
        Game.GetTowns()[0].HappinessRate = 0;
        Game.CurrenTown = Game.GetTowns()[0];
    }

    public void LoadDesertville()
    {
        Application.LoadLevel("Town2");
        Game.GetTowns()[1].HappinessRate = 0;
        Game.CurrenTown = Game.GetTowns()[1];
    }

    public void LoadOrienta()
    {
        Application.LoadLevel("Town3");
        Game.GetTowns()[2].HappinessRate = 0;
        Game.CurrenTown = Game.GetTowns()[2];
    }
}
