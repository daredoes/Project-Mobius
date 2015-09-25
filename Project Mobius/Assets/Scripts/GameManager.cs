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
    public GameObject OneUI;
    public GameObject ThreeUI;
    public GameObject fiveUI;

    //How many bars does the player want to use
    public int ButtonCount;

    public int barDistance = 10;

    public float barAndButtonWidth;

    //A list to store the instantiated Buttons and Bars
    public List<GameObject> Buttons;
	public List<GameObject> ButtonsP1;
	public List<GameObject> ButtonsP2;
    public List<GameObject> Bars;

    //Max amount of Buttons and Bars allowed in a scene
    int maxAmountOfButtons = 10;
    int maxAmountOfBars = 5;

    float startx;

    void Awake()
    {
		gm = this;
        ButtonCountSelectPanel.SetActive(true);


        ButtonsP1 = new List<GameObject>();
        ButtonsP2 = new List<GameObject>();

        /*
        Buttons = new List<GameObject>();
        Bars = new List<GameObject>();

        //Object Pooling at the start of the Game
        for (int i = 0; i < maxAmountOfBars; i++)
        {
            GameObject _bar = (GameObject)Instantiate(bar);
            _bar.SetActive(false);
            Bars.Add(_bar);
        }

        //Object Pooling at the start of the Game
        for (int i = 0; i < maxAmountOfButtons; i++)
        {
            GameObject _button = (GameObject)Instantiate(button);
            _button.SetActive(false);
			if(i % 2 == 0){
				ButtonsP1.Add(_button);
			}else{
				ButtonsP2.Add(_button);
			}
            
        }
        */
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
        //GenerateScene(ButtonCount);
        ButtonCountSelectPanel.SetActive(false);
    }


    /// <summary>
    /// functions for buttons to call to select the amount of buttons they want to play with
    /// </summary>
    public void Two()
    {
        ButtonCount = 3;
        DrawScene(ButtonCount, playerOne, playerTwo);
        //GenerateScene(ButtonCount);
        ButtonCountSelectPanel.SetActive(false);
    }


    /// <summary>
    /// functions for buttons to call to select the amount of buttons they want to play with
    /// </summary>
    public void Three()
    {
        ButtonCount = 5;
        DrawScene(ButtonCount, playerOne, playerTwo);
        //GenerateScene(ButtonCount);
        ButtonCountSelectPanel.SetActive(false);
    }

    public void DrawScene(int buttonAmount, GameObject p1, GameObject p2)
    {
        //Creating Buttons for PLAYER ONE
        for (int i = 0; i < buttonAmount; i++)
        {
            GameObject _button = (GameObject)Instantiate(button);
            _button.transform.SetParent(p1.transform, false);
        }

        //Creating Buttons for PLAYER TWO
        for (int i = 0; i < buttonAmount; i++)
        {
            GameObject _button = (GameObject)Instantiate(button);
            _button.transform.SetParent(p2.transform, false);
        }
    }


    public GameObject GetBars()
    {
        for (int i = 0; i < Bars.Count; i++)
        {
            if (!Bars[i].activeInHierarchy)
            {
                return Bars[i];
            }
        }
        return null;
    }

	public GameObject GetButtons()
	{
		for (int i = 0; i < Buttons.Count; i++)
		{
			if (!Buttons[i].activeInHierarchy)
			{
				return Buttons[i];
			}
		}
		return null;
	}

	public GameObject GetButtonsP1()
	{
		for (int i = 0; i < ButtonsP1.Count; i++)
		{
			if (!ButtonsP1[i].activeInHierarchy)
			{
				return ButtonsP1[i];
			}
		}
		return null;
	}

	public GameObject GetButtonsP2()
	{
		for (int i = 0; i < ButtonsP2.Count; i++)
		{
			if (!ButtonsP2[i].activeInHierarchy)
			{
				return ButtonsP2[i];
			}
		}
		return null;
	}

    void GenerateScene(int numButtons)
    {
		int flip = 1;
		int count = 0;

		for (int i = 0; i < numButtons; i++) {
			GameObject objTemp = GetBars();
			objTemp.transform.position = centerPos + new Vector2(seperatorIncrement * count * flip, 0);
			objTemp.transform.rotation = transform.rotation;

			objTemp.SetActive(true);

			objTemp = GetButtonsP1();
			objTemp.transform.position = centerP1 + new Vector2(seperatorIncrement * count * flip, 0);
			objTemp.transform.rotation = transform.rotation;
			objTemp.gameObject.GetComponent<button>().p1 = true;
			objTemp.SetActive(true);

			objTemp = GetButtonsP2();
			objTemp.transform.position = centerP2 + new Vector2(seperatorIncrement * count * flip, 0);
			objTemp.transform.rotation = transform.rotation;
			objTemp.gameObject.GetComponent<button>().p1 = true;
			
			objTemp.SetActive(true);

			if(count == 0){
				count++;
			}
			else{
				if(flip == 1){
					flip = -1;
				}
				else{
					flip = 1;
					count++;
				}
			}
		}
    }
}
