using UnityEngine;
using System.Collections;

public class playableObject : MonoBehaviour {

	public bool activated = false;
	// Use this for initialization
	void Start () {
	
	}

	public virtual void pause(){
		activated = false;
	}

	public virtual void unpause(){
		activated = true;
	}

	public virtual void pauseFlip(){
		activated = !activated;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
