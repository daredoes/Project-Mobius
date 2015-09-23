using UnityEngine;
using System.Collections;

public class beat_init : MonoBehaviour {
	bool flip;
	bool test;
	[Range(0.0f, 5.0f)]
	public static float travelLength = 1.0f;
	Vector2 startPosition;
	[Range(0.0f, .2f)]
	public float step = .05f;
	// Use this for initialization
	void Start () {
		startPosition = gameObject.transform.position;
		flip = false;
		test = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.y < startPosition.y - travelLength || gameObject.transform.position.y > startPosition.y + travelLength) {
			gameObject.transform.position = startPosition;
		}
		if (test) {
			if (flip) {
				gameObject.transform.Translate (Vector2.up * step);
			} else {
				gameObject.transform.Translate (Vector2.down * step);
			}
		}
		if (Input.GetKeyDown (KeyCode.J)) {
			gameObject.transform.position = startPosition;
		}
		if (Input.GetKeyDown (KeyCode.K)) {
			test = !test;
		}
		if (Input.GetKeyDown (KeyCode.L)) {
			gameObject.transform.Translate(Vector2.up * step);
		}
	
	}

	void bounce()
	{
		flip = !flip;
		Vector3 temp = gameObject.transform.localScale;
		temp.y *= -1;
		gameObject.transform.localScale = temp;
	}
	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == ("Floor"))
		{
		}

	}
}
	