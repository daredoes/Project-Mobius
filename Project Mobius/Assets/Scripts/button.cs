using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class button : MonoBehaviour {
	public bool p1;
	public KeyCode launch = KeyCode.H;
	public GameObject beatBar = null;
	public GameObject beatFab;
	public float barDist = 0.5f;
    public Camera mainCamera;
    Vector3 screenPos;
    Vector3 worldPos;

    void Awake()
    {
        mainCamera = Camera.main;
        screenPos = gameObject.transform.position;

        worldPos = mainCamera.ScreenToWorldPoint(screenPos);
    }

    // Use this for initialization
    void Start () {
		gameObject.GetComponent<Button> ().onClick.AddListener (() => {
			shootBar();
		});	
	}

 


	public void Spawned(bool p1Set){
        p1 = p1Set;
        if (beatBar == null)
        {
            getBeatBar();
        }
    }

	void shootBar(){
		beatBar.GetComponent<beatBouncer>().hit();
	}

	void getBeatBar(){
		beatBar = (GameObject)Instantiate (beatFab);
        beatBar.GetComponent<beatBouncer>().parentalUnit = this.gameObject;
        //Debug.Log("P1: " + p1);
		if (p1 == true) {
            beatBar.transform.position = transform.position + new Vector3(0, barDist * 1, 0);
            spawnBar (1);
		} 
		else {
            beatBar.transform.position = transform.position + new Vector3(0, barDist * -1, 0);
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
        if (Input.GetMouseButtonDown (0))
		{
			if (GetComponent<Collider2D> () == Physics2D.OverlapPoint (Camera.main.ScreenToWorldPoint (Input.mousePosition))) {
				beatBar.SendMessage("hit");
			}
		} 
        //Debug.Log("SCREENPOS: " + screenPos);
        //Debug.Log("WORLDPOS: " + worldPos);

    }
}
