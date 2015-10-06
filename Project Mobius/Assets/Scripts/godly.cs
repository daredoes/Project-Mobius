using UnityEngine;
using System.Collections;

public class godly : MonoBehaviour {
	//public bool audio;
	// Use this for initialization
	void Start () {
		//audio = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
	
	}
}
