using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class player_main : MonoBehaviour
{
	public bool isPlayerOne;
    public bool isai;
	[Range(0, 11)]
	public int score = 0;
	public Color color;

    public int buttonCount = 0;
	public List<KeyCode> keys;
	public List<GameObject> buttons;
    public Dictionary<int, GameObject> buttonDict;

    // Before Start function
    void Awake()
    {
		//gameObject.GetComponent<SpriteRenderer> ().color = color;
    }

    // Use this for initialization
    void Start ()
    {
        
    }

    void Update()
    {
        for(int l = 0; l < keys.Count; l++)
        {
            if (Input.GetKeyDown(keys[l]))
            {
                buttonDict[l].GetComponent<button>().shootBar();
            }
        }
        
    }

	public void pause(){
		foreach(GameObject b in buttons){
			b.GetComponent<button>().pause();
		}
	}

	public void unpause(){
		foreach(GameObject b in buttons){
			b.GetComponent<button>().unpause();
		}
	}

	public void pauseFlip(){
		foreach(GameObject b in buttons){
			b.GetComponent<button>().pauseFlip();
		}
	}

    public void spawned()
    {
        Vector3 temp;
        foreach(GameObject butt in buttons)
        {
            butt.GetComponent<button>().color = color;
            butt.GetComponent<button>().claimed();

            if (isPlayerOne)
            {
                temp = butt.GetComponent<button>().gameObject.transform.localScale;
                temp.x *= -1;
                butt.GetComponent<button>().gameObject.transform.localScale = temp;

                temp = butt.GetComponent<button>().beatBar.GetComponent<beatBouncer>().gameObject.transform.localScale;
                temp.x *= -1;
                butt.GetComponent<button>().beatBar.GetComponent<beatBouncer>().gameObject.transform.localScale = temp;
            }
        }
    }

    public void isAI()
    {
        isai = true;
        //player2Controls();
    }

    public void isPlayer1()
    {
        isPlayerOne = true;
        player1Controls();
    }

    public void isPlayer2()
    {
        isPlayerOne = false;
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
        //butt.GetComponent<button>().launch = keys[buttonCount];
        //butt.GetComponent<button>().setText();
        buttonDict.Add(buttonDict.Count, butt);
        //buttonCount++;
        buttons.Add(butt);
    }
}
