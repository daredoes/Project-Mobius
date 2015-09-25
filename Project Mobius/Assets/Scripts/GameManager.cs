using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager gm = null;

	public GameObject playerOne;
	public GameObject playerTwo;

	public int score;
	public float seperatorIncrement = .125f;
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
    public List<GameObject> Bars;

    //Max amount of Buttons and Bars allowed in a scene
    int maxAmountOfButtons = 10;
    int maxAmountOfBars = 5;

    float startx;

    void Awake()
    {
		gm = this;
        ButtonCountSelectPanel.SetActive(true);

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
            Buttons.Add(_button);
        }
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

        GenerateScene(ButtonCount);

        ButtonCountSelectPanel.SetActive(false);
        OneUI.SetActive(true);
        ThreeUI.SetActive(false);
        fiveUI.SetActive(false);
    }


    /// <summary>
    /// functions for buttons to call to select the amount of buttons they want to play with
    /// </summary>
    public void Two()
    {
        ButtonCount = 3;

        GenerateScene(ButtonCount);

        ButtonCountSelectPanel.SetActive(false);
        OneUI.SetActive(false);
        ThreeUI.SetActive(true);
        fiveUI.SetActive(false);
    }


    /// <summary>
    /// functions for buttons to call to select the amount of buttons they want to play with
    /// </summary>
    public void Three()
    {
        ButtonCount = 5;

        GenerateScene(ButtonCount);

        ButtonCountSelectPanel.SetActive(false);
        OneUI.SetActive(false);
        ThreeUI.SetActive(false);
        fiveUI.SetActive(true);
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
    void GenerateScene(int numButtons)
    {
        //If we were working with the UI only but were working in world space
        /*
        barAndButtonWidth = Screen.width / numButtons;
        Debug.Log(barAndButtonWidth);

        float barCenterPos = barAndButtonWidth / 2;
        */

		int flip = 1;
		int count = 0;

		for (int i = 0; i < numButtons; i++) {
			GameObject objTemp = GetBars();
			objTemp.transform.position = centerPos + new Vector2(seperatorIncrement * count * flip, 0);
			objTemp.transform.rotation = transform.rotation;

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
        /*switch(numButtons)
        {
            case 1:
                startx = 0;
                break;
            case 3:
                startx = 2;
                break;
            case 5:
                startx = 3;
                break;
            default:
                startx = 0;
                break;
        }

        for (int i = 0; i < numButtons; i++)
        {
            GameObject obj = GetBars();

            obj.transform.position = new Vector3(startx, 0, 0);
            obj.transform.rotation = transform.rotation;

            obj.SetActive(true);
            //Instantiate<GameObject>(button).transform.position

            switch (numButtons)
            {
                case 1:
                    startx = 0;
                    break;
                case 3:
                    startx -= 2;
                    break;
                case 5:
                    startx -= 1.5f;
                    break;
                default:
                    startx = 0;
                    break;
            }
        } */
    }

    
}
