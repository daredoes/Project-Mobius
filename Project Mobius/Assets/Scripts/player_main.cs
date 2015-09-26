using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class player_main : MonoBehaviour
{
	public bool isPlayerOne;
	[Range(0, 11)]
	public int score = 0;
	public Color color;

    public int buttonCount = 0;
	public List<KeyCode> keys;
	public List<GameObject> buttons;

    // Before Start function
    void Awake()
    {
		//gameObject.GetComponent<SpriteRenderer> ().color = color;
    }

    // Use this for initialization
    void Start () {
        

    }

    public void isPlayer1()
    {
        player1Controls();
    }

    public void isPlayer2()
    {
        player2Controls();
    }

    void player1Controls()
    {
        keys.Add(KeyCode.Q);
        keys.Add(KeyCode.W);
        keys.Add(KeyCode.E);
        keys.Add(KeyCode.R);
        keys.Add(KeyCode.T);
    }

    void player2Controls()
    {
        keys.Add(KeyCode.J);
        keys.Add(KeyCode.K);
        keys.Add(KeyCode.L);
        keys.Add(KeyCode.Semicolon);
        keys.Add(KeyCode.Quote);
    }

    public void addButton(GameObject butt)
    {
        butt.GetComponent<button>().launch = keys[buttonCount];
        buttonCount++;
        buttons.Add(butt);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
