using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class button : MonoBehaviour {
	public bool p1;
	public KeyCode launch = KeyCode.H;
	public GameObject beatBar = null;
	public GameObject beatFab;
	public static float barDist = 0.5f;


	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Button> ().onClick.AddListener (() => {
			shootBar();
		});

	
	}

	void Awake() {
		if(beatBar == null){
			getBeatBar();
		}
	}

	void spawned(){

	}

	void shootBar(){
		beatBar.SendMessage ("hit");

	}

	void getBeatBar(){
		beatBar = (GameObject)Instantiate (beatFab);
		if (p1) {
			beatBar.transform.position = new Vector3 (transform.position.x, transform.position.y + (barDist * 1), transform.position.z);
			beatBar.GetComponent<beatBouncer>().p1 = p1;
			beatBar.GetComponent<beatBouncer>().launch = launch;
			beatBar.SendMessage("spawned");
		} 
		else {
			beatBar.transform.position = new Vector3 (transform.position.x, transform.position.y + (barDist * -1), transform.position.z);
			beatBar.GetComponent<beatBouncer>().p1 = p1;
			beatBar.GetComponent<beatBouncer>().launch = launch;
			beatBar.SendMessage("spawned");

		}
	}

	// Update is called once per frame
	void Update () {
		/*if (Input.GetMouseButtonDown (0))
		{

			if (GetComponent<Collider2D> () == Physics2D.OverlapPoint (Camera.main.ScreenToWorldPoint (Input.mousePosition))) {
				beatBar.SendMessage("hit");
			}

		} */
	
	}
}
