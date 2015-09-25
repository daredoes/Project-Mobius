using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class player_main : MonoBehaviour
{
	public bool isPlayerOne;
	[Range(0, 11)]
	public int score = 0;
	public Color color;

	public List<KeyCode> keys;
	public List<GameObject> buttons;

    // Before Start function
    void Awake()
    {

    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
