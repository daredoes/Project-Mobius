using UnityEngine;
using System.Collections;

public class UIHandler : MonoBehaviour
{
    public GameObject OneUI;
    public GameObject ThreeUI;
    public GameObject fiveUI;

	// Use this for initialization
	void Awake ()
    {

	
	}
	
	// Update is called once per frame
	void Update ()
    {
        switch (GameManager.gm.ButtonCount)
        {
            case 1:
                ActivateOne();
                break;
            case 3:
                ActivateThree();
                break;
            case 5:
                ActivateFive();
                break;

        }
    }

    void ActivateOne()
    {

    }

    void ActivateThree()
    {

    }

    void ActivateFive()
    {

    }
}
