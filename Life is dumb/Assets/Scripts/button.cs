using UnityEngine;
using System.Collections;

public class button : MonoBehaviour {

    public bool p1;
    public bool barInstantiated;

    static float barDist = 0.5f;

    //BeatBar Prefab
	public GameObject beatBar;

    //Refrence GameObject (this beatButtons BeatBar)
    public GameObject myBar;

    //Refrence to Beat Bouncer Script
    beatBouncer _bb;

    void Awake()
    {
        
    }

    void Start()
    {
        if(gameObject.activeInHierarchy)
        {
            if(!barInstantiated)
            {
                InstantiateBar();
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (myBar != null)
                {
                    myBar.SendMessage("hit");
                }                
            }

        }

    }

    void InstantiateBar()
    {
        Vector3 Pos = transform.position;
        if (p1)
        {
            myBar = (GameObject)Instantiate(beatBar);
            myBar.GetComponent<beatBouncer>().p1 = p1;
            myBar.transform.SetParent(this.transform);
            myBar.transform.position = new Vector3(Pos.x, Pos.y + (barDist * 1), Pos.z);
            barInstantiated = true;
            
        }
        else if (!p1)
        {
            myBar = (GameObject)Instantiate(beatBar);
            myBar.GetComponent<beatBouncer>().p1 = p1;
            myBar.transform.SetParent(this.transform);
            myBar.transform.position = new Vector3(Pos.x, Pos.y + (barDist * -1), Pos.z);
            barInstantiated = true;
        }
    }
}
