using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class player_main : MonoBehaviour
{
	private GameObject[] beatBars;
	public List<KeyCode> keys;
	public static float howBarApart = 2.0f;

    // Before Start function
    void Awake()
    {

        ///barCount = 3;
    }

    // Use this for initialization
    void Start () {

	}

	void generateBeatBars(int count)
	{
		beatBars = new GameObject[count];
		for (int i = 0; i < count; i++) {

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
