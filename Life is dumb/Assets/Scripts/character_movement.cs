using UnityEngine;
using System.Collections;

public class character_movement : MonoBehaviour {
	private Rigidbody2D body;
	Transform trans;
	float moveStep = .2f;
	int push = 25;
	// Use this for initialization
	void Start () {
		trans = gameObject.transform;
		body = gameObject.GetComponent<Rigidbody2D> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W)) {
			body.AddForce(new Vector2(0, push));
		}
		if (Input.GetKey (KeyCode.A)) {
			body.AddForce(new Vector2(push*-1, 0));
		}
		if (Input.GetKey(KeyCode.S)) {
			body.AddForce(new Vector2(0, push*-1));
		}
		if (Input.GetKey (KeyCode.D)) {
			body.AddForce(new Vector2(push, 0));
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			body.simulated = !body.simulated;
		}
	
	}
}
