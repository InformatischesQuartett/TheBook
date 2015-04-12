using UnityEngine;
using UnityEngine.UI;

public class IntScript : MonoBehaviour
{
    private bool _active;
    private bool _talking;

    private GameObject _other;

    void Start()
    {
        _talking = false;
    }

    public void ShowBubble(GameObject other)
    {
        _active = true;
        _other = other;

        this.GetComponent<SpriteRenderer>().enabled = _active;
    }

    public void HideBubble()
    {
        _active = false;
        this.GetComponent<SpriteRenderer>().enabled = _active;
    }

    void Update()
    {
        if (!_active)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _other.GetComponent<Animator>().SetBool("Walk", false);
            _other.GetComponent<Animator>().SetBool("Talk", true);
            
            int rand = Random.RandomRange(0, Game.CurrenTown.GetBeliefs().Count);
            var townBeliefs = Game.CurrenTown.GetBeliefs();
            var belief = townBeliefs[rand];
            var go = GameObject.Find("Game");
            Book book = go.GetComponent<Book>();
            foreach (var rule in book._ruleList)
            {
                if (rule.RuleName == belief.beliefName)
                {
                    book.WriteRule(rule);
                }
            }

        }
    }
}
