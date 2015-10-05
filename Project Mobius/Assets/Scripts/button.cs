using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class button : playableObject
{
	//true  = p1 | false = p2
	public bool p1;
	//Is AI Player?
	public bool isAI;
	//Keyboard launch key
	public KeyCode launch = KeyCode.H;
	//Spawned bar
	public GameObject beatBar = null;
	//Prefab of bar
	public GameObject beatFab;
	//Distance from center of button to center of bar
	public float barDist = 0.5f;
	//Percent scale of button
	private float scaler = 0.10f;
	//Sprite Renderer for flips and such
	private SpriteRenderer sprender;
	//Camera
	public Camera mainCamera;
	//Color of button and bar
	public Color color;
	//text for trigger
	public Text DisplayText;
	//Beat that will interact with button
	public GameObject matchedBeat;
	public bool tapped = false;

	void Awake ()
	{
		//Set camera
		mainCamera = Camera.main;
		//Get SpriteRenderer
		sprender = GetComponent<SpriteRenderer> ();
		//Resize sprite
		sprender.transform.localScale = sprender.transform.localScale + new Vector3 (scaler, scaler, scaler);
		//Set display text
		DisplayText = GetComponent<Text> ();
		DisplayText.GetComponent<Renderer> ().sortingLayerID = transform.GetComponent<Renderer> ().sortingLayerID;
	}

	// Use this for initialization
	void Start ()
	{
		isAI = GetComponentInParent<player_main> ().isai;
		gameObject.GetComponent<Button> ().onClick.AddListener (() => {
			shootBar ();
		});	
	}

	public override void pause(){
		base.pause ();
		beatBar.GetComponent<beatBouncer> ().pause ();
	}

	public override void unpause(){
		base.unpause ();
		beatBar.GetComponent<beatBouncer> ().unpause ();
	}

	public override void pauseFlip(){
		base.pauseFlip ();
		beatBar.GetComponent<beatBouncer> ().pauseFlip ();
	}

	public void claimed ()
	{
		gameObject.GetComponent<SpriteRenderer> ().color = color;
		beatBar.GetComponent<SpriteRenderer> ().color = color;
	}

	public void setText ()
	{
		DisplayText.text = launch.ToString ();
	}

	public void Spawned (bool p1Set)
	{
		p1 = p1Set;
		if (beatBar == null) {
			getBeatBar ();
		}
		/*
        * HEY CRISTIAN I NEED YOU TO MAKE THE TEXT APPEAR ABOVE THE BUTTON SPRITES!
        * I MADE IT SET TO THE SPECIAL KEY IT GETS TO SERVE ITS FUNCTIONS
        * I DONT KNOW UNITY UI. I STAY HERE. CODE IS SAFE. @_%
        */
        
	}

	void shootBar ()
	{
		beatBar.GetComponent<beatBouncer> ().hit ();
	}

	void getBeatBar ()
	{
		beatBar = (GameObject)Instantiate (beatFab);
		//beatBar.GetComponent<beatBouncer>().parentalUnit = this.gameObject;
		//Debug.Log("P1: " + p1);

		if (p1) {
			beatBar.transform.position = transform.position + new Vector3 (0, barDist * 1 * transform.localScale.y, 0);
			spawnBar (1);
		} else {
			beatBar.transform.position = transform.position + new Vector3 (0, barDist * -1 * transform.localScale.y, 0);
			spawnBar (-1);
		}

		beatBar.transform.SetParent (this.transform, true);
	}

	void spawnBar (int aboveBelow)
	{
		//beatBar.transform.position;
		beatBar.GetComponent<beatBouncer> ().p1 = p1;
		//beatBar.GetComponent<beatBouncer>().launch = launch;
		beatBar.GetComponent<beatBouncer> ().spawned ();
	}

	// Update is called once per frame
	void Update ()
	{
		if (activated) {
			if (!isAI) {
				if (Input.GetKeyDown (launch)) {
					shootBar ();
				}
				/*if (Input.GetMouseButtonDown (0))
		{
			if (GetComponent<Collider2D> () == Physics2D.OverlapPoint (Camera.main.ScreenToWorldPoint (Input.mousePosition))) {
				beatBar.SendMessage("hit");
			}
		} */

				var touchCount = Input.touchCount;
				for (var i = 0; i < touchCount; i++) {
					var touch = Input.GetTouch (i);
					if (touch.phase == TouchPhase.Began) {
						if (!tapped) {
							if (GetComponent<Collider2D> () == Physics2D.OverlapPoint (Camera.main.ScreenToWorldPoint (touch.position))) {
								tapped = true;
								beatBar.GetComponent<beatBouncer> ().hit ();
							}
						}
					}
					if (touch.phase == TouchPhase.Moved) {
						if (!tapped) {
							if (GetComponent<Collider2D> () == Physics2D.OverlapPoint (Camera.main.ScreenToWorldPoint (touch.position))) {
								tapped = true;
								beatBar.GetComponent<beatBouncer> ().hit ();
							}
						}
					}
					if (touch.phase == TouchPhase.Ended) {
						tapped = false;
					}
				}
			}
		}
		//Debug.Log("SCREENPOS: " + screenPos);
		//Debug.Log("WORLDPOS: " + worldPos);

	}

}
