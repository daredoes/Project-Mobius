using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class button : MonoBehaviour {
	public bool p1;
	public KeyCode launch = KeyCode.H;
	public GameObject beatBar = null;
	public GameObject beatFab;
	public float barDist = 0.5f;
	private float scaler = 0.10f;
	private SpriteRenderer sprender;
    public Camera mainCamera;
    Vector3 screenPos;
    Vector3 worldPos;
    public Color color;
    public Text DisplayText;

    void Awake()
    {
        mainCamera = Camera.main;
		sprender = GetComponent<SpriteRenderer> ();
		sprender.transform.localScale = sprender.transform.localScale += new Vector3 (scaler, scaler, scaler);
        DisplayText = GetComponent<Text>();
        DisplayText.GetComponent<Renderer>().sortingLayerID = transform.GetComponent<Renderer>().sortingLayerID;
        screenPos = gameObject.transform.position;

        worldPos = mainCamera.ScreenToWorldPoint(screenPos);
    }

    // Use this for initialization
    void Start () {
		gameObject.GetComponent<Button> ().onClick.AddListener (() => {
			shootBar();
		});	
	}

    public void claimed()
    {
        gameObject.GetComponent<SpriteRenderer>().color = color;
        beatBar.GetComponent<SpriteRenderer>().color = color;
    }

    public void setText()
    {
        DisplayText.text = launch.ToString();
    }

	public void Spawned(bool p1Set){
        p1 = p1Set;
        if (beatBar == null)
        {
            getBeatBar();
        }
        /*
        * HEY CRISTIAN I NEED YOU TO MAKE THE TEXT APPEAR ABOVE THE BUTTON SPRITES!
        * I MADE IT SET TO THE SPECIAL KEY IT GETS TO SERVE ITS FUNCTIONS
        * I DONT KNOW UNITY UI. I STAY HERE. CODE IS SAFE. @_%
        */
        
    }

	void shootBar(){
		beatBar.GetComponent<beatBouncer>().hit();
	}

	void getBeatBar(){
		beatBar = (GameObject)Instantiate (beatFab);
        beatBar.GetComponent<beatBouncer>().parentalUnit = this.gameObject;
        //Debug.Log("P1: " + p1);
		if (p1 == true) {
            beatBar.transform.position = transform.position + new Vector3(0, barDist * 1 * transform.localScale.y, 0);
            spawnBar (1);
		} 
		else {
			beatBar.transform.position = transform.position + new Vector3(0, barDist * -1 * transform.localScale.y, 0);
            spawnBar(-1);

		}
	}

	void spawnBar(int aboveBelow){
        //beatBar.transform.position;
		beatBar.GetComponent<beatBouncer>().p1 = p1;
		//beatBar.GetComponent<beatBouncer>().launch = launch;
		beatBar.GetComponent<beatBouncer>().spawned();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (launch)) {
			shootBar();
		}
        /*if (Input.GetMouseButtonDown (0))
		{
			if (GetComponent<Collider2D> () == Physics2D.OverlapPoint (Camera.main.ScreenToWorldPoint (Input.mousePosition))) {
				beatBar.SendMessage("hit");
			}
		} */

        var touchCount = Input.touchCount;
        for (var i = 0; i < touchCount; i++)
        {
            var touch = Input.GetTouch(i);
			if(touch.phase == TouchPhase.Began){
		        if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(touch.position)))
		        {
		            beatBar.GetComponent<beatBouncer>().hit ();
		        }
			}
        }
        //Debug.Log("SCREENPOS: " + screenPos);
        //Debug.Log("WORLDPOS: " + worldPos);

    }
}
