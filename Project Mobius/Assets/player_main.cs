﻿using UnityEngine;
using System.Collections;

public class player_main : MonoBehaviour {
	private GameObject[] beatBars;
	private Vector2 middleBeatPosition = new Vector2(0, -1);
	private float howBarApart = 2.0f;

	// Use this for initialization
	void Start () {

	}

	void generateBeatBars(int count)
	{
		beatBars = new GameObject[count];
		for (int i = 0; i < count; i++) {

		}
	}
	void Awake(){


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
