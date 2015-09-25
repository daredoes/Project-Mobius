using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class button : MonoBehaviour {
	public bool p1;
	public KeyCode launch = KeyCode.H;
	public GameObject beatBar = null;
	public GameObject beatFab;
	public static float barDist = 0.5f;
    public Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    // Use this for initialization
    void Start () {
		gameObject.GetComponent<Button> ().onClick.AddListener (() => {
			shootBar();
		});
		if(beatBar == null && GameManager.gm != null){
			getBeatBar();
		}

	
	}


	void spawned(){

	}

	void shootBar(){
		beatBar.GetComponent<beatBouncer>().hit();

	}

	void getBeatBar(){
		beatBar = (GameObject)Instantiate (beatFab);
		if (p1) {
			spawnBar (1);
		} 
		else {
			spawnBar(-1);

		}
	}

	void spawnBar(int aboveBelow){
		beatBar.transform.position = new Vector3 (mainCamera.ScreenToWorldPoint(this.transform.) transform.position.x, transform.position.y + (barDist * aboveBelow), transform.position.z);
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
	
	}
}
