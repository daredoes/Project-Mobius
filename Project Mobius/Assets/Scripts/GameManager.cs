using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm = null;
    public GameObject buttonCanvas;
    //Scenes that Cristian made for placing things around.
	public GameObject playerOne;
	public GameObject playerTwo;
    //Objects Daniel made that hold variable data on each player.
    public GameObject player1;
    public GameObject player2;

    float travelLength = 2.5f;

    public int score;
	public float seperatorIncrement = 1.0f;
	//public music audioTtrack;
	public bool online;
	public Vector2 centerPos = new Vector2 (0, 0);
    Vector3 centerP1 = new Vector3(0, -2.5f, 0);
	Vector3 centerP2 = new Vector3(0, 2.5f, 0);

    //Button Prefab
    public GameObject button;

    //Beat Prefab
    public GameObject beat;

    //Player Prefab
    public GameObject player;

    //Bar Prefab
	public GameObject bar;

    //countDown Prfab
    public GameObject CountDownPanel;

    //Reference to Button Selection Panel/other UI elements to toggle on and off
    public GameObject ButtonCountSelectPanel;

    //How many bars does the player want to use
    public int ButtonCount;

    public int barDistance = 10;

    public float barAndButtonWidth;

    float startx;

    /*Beginning timer variables*/
    bool startWait = false;
    public float startWaitSec = 3f;
    public bool hasDrawnScene = false;
    //Start Screen Timer
    public Text startTimer;
    //In Game Timer
    public Text gameTimer;
    float minutes = 1f;
    float seconds = 0;
    float miliseconds = 0;

    void Awake()
    {
		gm = this;
        ButtonCountSelectPanel.SetActive(true);
        centerP1 = new Vector3(0, travelLength *-1, 0);
        centerP2 = new Vector3(0, travelLength, 0);
    }

	void Start ()
    {
        /*MAKING A WAITING FUNCTION TO START SO THE PLAYERS HAVE A VISUAL QUEUE*/
        startTimer = GameObject.FindGameObjectWithTag("timer").GetComponent<Text>();
        gameTimer = GameObject.FindGameObjectWithTag("inGameTimer").GetComponent<Text>();
    }

    void Update ()
    {
        startTimer.text = Mathf.CeilToInt(startWaitSec).ToString();
       
        gameTimer.text = string.Format("Timer: {0}:{1}:{2}", minutes, seconds, (int)miliseconds);

        if (startWait)
        {
            if (startWaitSec > 0)
            {
                startWaitSec -= Time.deltaTime;
            }
            else
            {
                startWaitSec = 0;
            }
        }

        if (startWaitSec == 0 && !hasDrawnScene)
        {
            /*  
                I KNOW I COULD PUT THIS IN THE ELSE STATEMENT ABOVE BUT I JUST WANTED IT
                SEPERATED.

                YOU CAN DRAW SCENE WHEN BUTTON IS CLICKED, WHERE I COMMENTED IT OUT
                BUT HERE IS WHERE YOU CAN MAKE THE BEAT ACTUALLY BEGIN MOVING

                FOR NOW IM JUST MAKING IT DRAW THE SCENE AND START AFTER THE COUNTER
                HAS COMPLETELY GONE TO 0.

                OR WE CAN MAKE ONE MORE UI PANEL THAT BASICALLY DISPLAYS THE COUNTER LIKE
                        -READY
                        -3
                        -2                      //I THINK THIS IS WHAT I WILL DO FOR NOW.
                        -1
                        -GO!
                AND THEN BEGIN THE GAME
            */
            DrawScene(ButtonCount, playerOne, playerTwo);
            CountDownPanel.SetActive(false);
        }

        if(startWaitSec == 0 && hasDrawnScene)
        {
            if (miliseconds <= 0)
            {
                if (seconds <= 0)
                {
                    minutes--;
                    seconds = 59;
                }
                else if (seconds >= 0)
                {
                    seconds--;
                }

                miliseconds = 100;
            }
            miliseconds -= Time.deltaTime * 100;
        }
    }


    /// <summary>
    /// functions for buttons to call to select the amount of buttons they want to play with
    /// </summary>
    public void One()
    {
        ButtonCount = 1;
        //DrawScene(ButtonCount, playerOne, playerTwo);
        startWait = true;
        ButtonCountSelectPanel.SetActive(false);
        CountDownPanel.SetActive(true);
    }


    /// <summary>
    /// functions for buttons to call to select the amount of buttons they want to play with
    /// </summary>
    public void Two()
    {
        ButtonCount = 3;
        //DrawScene(ButtonCount, playerOne, playerTwo);
        startWait = true;
        ButtonCountSelectPanel.SetActive(false);
        CountDownPanel.SetActive(true);
    }


    /// <summary>
    /// functions for buttons to call to select the amount of buttons they want to play with
    /// </summary>
    public void Three()
    {
        ButtonCount = 5;
        //DrawScene(ButtonCount, playerOne, playerTwo);
        startWait = true;
        ButtonCountSelectPanel.SetActive(false);
        CountDownPanel.SetActive(true);
    }

    public void DrawScene(int buttonAmount, GameObject p1, GameObject p2)
    {
        hasDrawnScene = true;


        int count = 0;
        int flip = 1;
        player1 = (GameObject)Instantiate(player);
        player2 = (GameObject)Instantiate(player);

        player1.GetComponent<player_main>().color = Color.green;
        player2.GetComponent<player_main>().color = Color.magenta;

        player1.GetComponent<player_main>().isPlayer1();
        player2.GetComponent<player_main>().isPlayer2();
        for (int i = 0; i < buttonAmount; i++)
        {
            GameObject newBeat = (GameObject)Instantiate(beat);
            newBeat.transform.position = centerPos + new Vector2(seperatorIncrement * flip * count, 0);
            newBeat.GetComponent<beat_init>().travelLength = travelLength - 0.5f ;
            newBeat.GetComponent<beat_init>().startGame();

            GameObject spawnButton1 = (GameObject)Instantiate(button);
           // spawnButton1.transform.SetParent(buttonCanvas.transform);
            spawnButton1.transform.position = centerP1 + new Vector3(seperatorIncrement * flip * count, 0, 0);
            spawnButton1.GetComponent<button>().Spawned(true);
            player1.GetComponent<player_main>().addButton(spawnButton1);

            GameObject spawnButton2 = (GameObject)Instantiate(button);
            //spawnButton2.transform.SetParent(buttonCanvas.transform);
            spawnButton2.transform.position = centerP2 + new Vector3(seperatorIncrement * flip * count, 0, 0);
            spawnButton2.GetComponent<button>().Spawned(false);
            player2.GetComponent<player_main>().addButton(spawnButton2);

			Physics2D.IgnoreCollision(newBeat.GetComponent<Collider2D>(), spawnButton1.GetComponent<Collider2D>(), true);
			Physics2D.IgnoreCollision(newBeat.GetComponent<Collider2D>(), spawnButton2.GetComponent<Collider2D>(), true);

            if (flip == 1)
            {
                flip = -1;
                count++;
            }
            else
            {
                flip = 1;
            }


        }
        player1.GetComponent<player_main>().spawned();
        player2.GetComponent<player_main>().spawned();
        /*
        //Creating Buttons for PLAYER ONE
        for (int i = 0; i < buttonAmount; i++)
        {
            GameObject _button = (GameObject)Instantiate(button);
            _button.transform.SetParent(p1.transform, false);
            _button.GetComponent<button>().Spawned(true);
        }
       

        //Creating Buttons for PLAYER TWO
        for (int i = 0; i < buttonAmount; i++)
        {
            GameObject _button = (GameObject)Instantiate(button);
            _button.transform.SetParent(p2.transform, false);
            button.GetComponent<button>().Spawned(false);
        } */
    }
}
