using UnityEngine;

public class IntScript : MonoBehaviour
{
    private bool _active;

    public void ShowBubble(bool active)
    {
        _active = active;
        this.GetComponent<SpriteRenderer>().enabled = active;
    }

    void Update()
    {
        if (!_active)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
            Debug.Log("HELLO! HELLO! HEEEEELLLOOOO!");
    }
}
