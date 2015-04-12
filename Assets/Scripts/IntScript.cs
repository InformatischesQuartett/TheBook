using UnityEngine;
using UnityEngine.UI;

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
        {
            Debug.Log("HELLO! HELLO! HEEEEELLLOOOO!");
            
            int rand = Random.RandomRange(0, Game.CurrenTown.GetBeliefs().Count);
            var townBeliefs = Game.CurrenTown.GetBeliefs();
            var belief = townBeliefs[rand];
            var go = GameObject.Find("Game");
            Book book = go.GetComponent<Book>();
            book.AddNewRule(new Rule(belief.rule, belief.beliefName));
        }
    }
}
