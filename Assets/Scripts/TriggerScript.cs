using UnityEngine;

public class TriggerScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.tag == "NPC")
            gameObject.BroadcastMessage("ShowBubble", other.gameObject);
        //if (gameObject.tag == "Stage")
        //    Application.LoadLevel("Mapscreen");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (gameObject.tag == "NPC")
            gameObject.BroadcastMessage("HideBubble");
    }
}
