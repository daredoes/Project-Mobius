using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager gm = null;

	public GameObject playerOne;
	public GameObject playerTwo;

	public int score;
	public float seperatorIncrement = .025f;
	//public music audioTtrack;
	public bool online;
	public Vector2 centerPos = new Vector2 (0, 0);
	public Vector2 centerP1 = new Vector2 (0, -1);
	public Vector2 centerP2 = new Vector2(0, 1);

    //Button Prefab
    public GameObject button;

    //Bar Prefab
	public GameObject bar;

    //Reference to Button Selection Panel/other UI elements to toggle on and off
    public GameObject ButtonCountSelectPanel;

    //How many bars does the player want to use
    public int ButtonCount;

    public int barDistance = 10;

    public float barAndButtonWidth;

    float startx;

    void Awake()
    {
		gm = this;
        ButtonCountSelectPanel.SetActive(true);
    }

	void Start ()
    {
	
	}
	
	void Update ()
    {
	
	}


    /// <summary>
    /// functions for buttons to call to select the amount of buttons they want to play with
    /// </summary>
    public void One()
    {
        ButtonCount = 1;
        DrawScene(ButtonCount, playerOne, playerTwo);
        ButtonCountSelectPanel.SetActive(false);
    }


    /// <summary>
    /// functions for buttons to call to select the amount of buttons they want to play with
    /// </summary>
    public void Two()
    {
        ButtonCount = 3;
        DrawScene(ButtonCount, playerOne, playerTwo);
        ButtonCountSelectPanel.SetActive(false);
    }


    /// <summary>
    /// functions for buttons to call to select the amount of buttons they want to play with
    /// </summary>
    public void Three()
    {
        ButtonCount = 5;
        DrawScene(ButtonCount, playerOne, playerTwo);
        ButtonCountSelectPanel.SetActive(false);
    }

    public void DrawScene(int buttonAmount, GameObject p1, GameObject p2)
    {
        //Creating Buttons for PLAYER ONE
        for (int i = 0; i < buttonAmount; i++)
        {
            GameObject _button = (GameObject)Instantiate(button);
            _button.transform.SetParent(p1.transform, false);
            _button.GetComponent<button>().Spawned();
        }
       

        //Creating Buttons for PLAYER TWO
        for (int i = 0; i < buttonAmount; i++)
        {
            GameObject _button = (GameObject)Instantiate(button);
            _button.transform.SetParent(p2.transform, false);
        }
    }
}
