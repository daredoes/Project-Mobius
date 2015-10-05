using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager gm = null;
	//Scenes that Cristian made for placing things around.
	public GameObject playerOne;
	public GameObject playerTwo;
	//Objects Daniel made that hold variable data on each player.
	public GameObject player1;
	public GameObject player2;

	//How far the beat travels. Also 1/2 beat travelDiameter
	float travelLength = 2.5f;
	//Not sure how to use score
	public int score;
	//Distance between buttons when placed
	public float seperatorIncrement = 1.0f;
	private float sepHeight = 0.25f;
	//center point for 1st beat
	public Vector2 centerPos = new Vector2 (0, 0);
	//center point for P1 1st button
	Vector3 centerP1 = new Vector3 (0, -2.5f, 0);
	//center point for P2 1st button
	Vector3 centerP2 = new Vector3 (0, 2.5f, 0);
	
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
	
	//Player One Text Score
	public Text playerOneScore;
	
	//Player Two Text Score
	public Text playerTwoScore;
	
	//USE AI SCRIPT
	public bool singlePlayer;
	public bool localMultPlayer;
	public bool online;

	//0 = easy | 1 = medium | 2 = hard
	public int difficulty;
	
	void Awake ()
	{
		//Set Global Game Manager
		//Access with GameManager.gm
		gm = this;
		//Set Preferences for Modes
		singlePlayer = Prefs.playerPrefs.single;
		localMultPlayer = Prefs.playerPrefs.local;
		online = Prefs.playerPrefs.online;
		//CountDownPanel = GameObject.FindGameObjectWithTag("countDownUI");
		//ButtonCountSelectPanel = GameObject.FindGameObjectWithTag("buttonSelectionUI");
		//playerOneScore = GameObject.FindGameObjectWithTag("playerOneText").GetComponent<Text>();
		//playerTwoScore = GameObject.FindGameObjectWithTag("playerTwoText").GetComponent<Text>();

		//Display Panel
		ButtonCountSelectPanel.SetActive (true);

		//Set 1st button position for both players
		centerP1 = new Vector3 (0, travelLength * -1, 0);
		centerP2 = new Vector3 (0, travelLength, 0);
	}
	
	void Start ()
	{            
		/*MAKING A WAITING FUNCTION TO START SO THE PLAYERS HAVE A VISUAL QUEUE*/
		startTimer = GameObject.FindGameObjectWithTag ("timer").GetComponent<Text> ();
		gameTimer = GameObject.FindGameObjectWithTag ("inGameTimer").GetComponent<Text> ();   
	}
	
	void Update ()
	{
		//change start timer text
		startTimer.text = Mathf.CeilToInt (startWaitSec).ToString ();

		//Update in game timer
		gameTimer.text = string.Format ("Timer: {0}:{1}:{2}", minutes, seconds, (int)miliseconds);


		//Cristian please comment how this chunk works
		//Cristian
		//Cristian
		//Cristian
		//Cristian
		//Cristian
		//Cristian
		if (startWait) {
			if (startWaitSec > 0) {
				startWaitSec -= Time.deltaTime;
			} else {
				startWaitSec = 0;
			}
		}

		//Cristian
		//Cristian
		if (startWaitSec == 0 && !hasDrawnScene) {
			DrawScene (ButtonCount, playerOne, playerTwo);
			CountDownPanel.SetActive (false);
		}

		//Cristian
		//Cristian
		if (hasDrawnScene) {
			playerOneScore.text = player1.GetComponent<player_main> ().score.ToString ();
			
			playerTwoScore.text = player2.GetComponent<player_main> ().score.ToString ();
		}

		//Cristian
		//Cristian
		if (startWaitSec == 0 && hasDrawnScene) {
			if (miliseconds <= 0) {
				if (seconds <= 0) {
					minutes--;
					seconds = 59;
				} else if (seconds >= 0) {
					seconds--;
				}
				
				miliseconds = 100;
			}
			miliseconds -= Time.deltaTime * 100;
		}
	}

	//Cristian
	//Cristian
	public void One ()
	{
		ButtonCount = 1;
		difficulty = 0;
		//DrawScene(ButtonCount, playerOne, playerTwo);
		startWait = true;
		ButtonCountSelectPanel.SetActive (false);
		CountDownPanel.SetActive (true);
	}
	

	//Cristian
	//Cristian
	public void Two ()
	{
		ButtonCount = 3;
		difficulty = 1;
		//DrawScene(ButtonCount, playerOne, playerTwo);
		startWait = true;
		ButtonCountSelectPanel.SetActive (false);
		CountDownPanel.SetActive (true);
	}

	//Cristian
	//Cristian
	public void Three ()
	{
		ButtonCount = 5;
		difficulty = 2;
		//DrawScene(ButtonCount, playerOne, playerTwo);
		startWait = true;
		ButtonCountSelectPanel.SetActive (false);
		CountDownPanel.SetActive (true);
	}

	//Cristian
	//Cristian
	public void DrawScene (int buttonAmount, GameObject p1, GameObject p2)
	{
		//Temp variables for placement purposes
		int count = 0;
		int flip = 1;

		//Instantiate players on Game Start
		player1 = (GameObject)Instantiate (player, Vector3.zero, Quaternion.identity);
		player2 = (GameObject)Instantiate (player, Vector3.zero, Quaternion.identity);

		//Set player colors
		player1.GetComponent<player_main> ().color = Color.green;
		player2.GetComponent<player_main> ().color = Color.magenta;

		//Set player1 as human
		player1.GetComponent<player_main> ().isPlayer1 ();
		player2.GetComponent<player_main> ().isPlayer2 ();

		//Choose player2 through mode select
		if (singlePlayer) {
			player1.GetComponent<player_main> ().isAI ();
			player2.GetComponent<player_main> ().isAI ();
		} else if (localMultPlayer) {
			player2.GetComponent<player_main> ().isPlayer2 ();
		}


		//Spawn Buttons and Beats
		for (int i = 0; i < buttonAmount; i++) {
			GameObject newBeat = (GameObject)Instantiate (beat);
			if (i < 3) {
				newBeat.transform.position = centerPos + new Vector2 (seperatorIncrement * flip * count, 0);
				newBeat.GetComponent<beat_init> ().travelLength = travelLength;
			} else {
				newBeat.transform.position = centerPos + new Vector2 (seperatorIncrement / 2 * flip, 0);
				newBeat.GetComponent<beat_init> ().travelLength = travelLength - sepHeight;
			}
			
			
			newBeat.GetComponent<beat_init> ().startGame ();
			
			GameObject spawnButton1 = (GameObject)Instantiate (button);
			// spawnButton1.transform.SetParent(buttonCanvas.transform);
			if (i < 3) {
				spawnButton1.transform.position = centerP1 + new Vector3 (seperatorIncrement * flip * count, 0, 0);
			} else {
				spawnButton1.transform.position = centerP1 + new Vector3 (seperatorIncrement / 2 * flip, sepHeight, 0);
			}
			spawnButton1.GetComponent<button>().matchedBeat = newBeat;
			spawnButton1.GetComponent<button> ().Spawned (true);
			player1.GetComponent<player_main> ().addButton (spawnButton1);
			spawnButton1.transform.SetParent(player1.transform, true);
			
			GameObject spawnButton2 = (GameObject)Instantiate (button);
			//spawnButton2.transform.SetParent(buttonCanvas.transform);
			if (i < 3) {
				spawnButton2.transform.position = centerP2 + new Vector3 (seperatorIncrement * flip * count, 0, 0);
			} else {
				spawnButton2.transform.position = centerP2 + new Vector3 (seperatorIncrement / 2 * flip, sepHeight * -1.0f, 0);
			}
			spawnButton2.GetComponent<button>().matchedBeat = newBeat;
			spawnButton2.GetComponent<button> ().Spawned (false);
			player2.GetComponent<player_main> ().addButton (spawnButton2);
			spawnButton2.transform.SetParent(player2.transform, true);

			//Stop collision between beat and buttons
			Physics2D.IgnoreCollision (newBeat.GetComponent<Collider2D> (), spawnButton1.GetComponent<Collider2D> (), true);
			Physics2D.IgnoreCollision (newBeat.GetComponent<Collider2D> (), spawnButton2.GetComponent<Collider2D> (), true);

			//Alternate which side the button is placed on
			if (flip == 1) {
				flip = -1;
				count++;
			} else {
				flip = 1;
			}
			
		}

		//Tell players to finish spawning
		player1.GetComponent<player_main> ().spawned ();
		player2.GetComponent<player_main> ().spawned ();

		//Scene Drawn
		hasDrawnScene = true;
	}
}