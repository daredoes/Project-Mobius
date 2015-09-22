using UnityEngine;
using System.Collections;

public class beatBouncer : MonoBehaviour
{
	//flip = -1 (Moves down) flip = 1 (Moves up)
	[Range(-1, 1)]
	public int
		flip;
	public float distance = 25.0f;
	public bool moving;
	private Collider2D matchedBeat = null;
	bool hollow;
	public float speed = .05f;
	public float returnSpeedModifier = .25f;
	private Vector2 startPosition;
	// Use this for initialization
	void Start ()
	{
		moving = false;
		hollow = true;
		startPosition = gameObject.transform.position;

	}

	public bool isAtStart ()
	{
		return (Vector2)gameObject.transform.position == (Vector2)startPosition;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (0) && !moving) {

			if (GetComponent<Collider2D> () == Physics2D.OverlapPoint (Camera.main.ScreenToWorldPoint (Input.mousePosition))) {
				if (isAtStart ()) {
					moving = true;
					hollow = false;
					Physics2D.IgnoreCollision(matchedBeat, GetComponent<Collider2D>(), false);
				}
				
			}
		}
		if (moving) {
			if (flip == 1) {
				if (gameObject.transform.position.y < startPosition.y + (distance)) {
					gameObject.transform.Translate (new Vector2 (0, flip) * speed);
				} else {
					moving = false;
				}
			} else if (flip == -1) {
				if (gameObject.transform.position.y > startPosition.y - (distance)) {
					gameObject.transform.Translate (new Vector2 (0, flip) * speed);
				} else {
					moving = false;
				}
			}

		} else {
			hollow = true;
			if ((Vector2)gameObject.transform.position != (Vector2)startPosition) {
				gameObject.transform.position = Vector2.MoveTowards (gameObject.transform.position, startPosition, speed * returnSpeedModifier);
			}
		}
	
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == ("Beat")) {
			if(matchedBeat == null)
			{
				matchedBeat = other.gameObject.GetComponent<Collider2D>();
			}
			if (!hollow) {
				other.gameObject.SendMessage ("bounce");
			}
			else{
				Physics2D.IgnoreCollision(other.transform.GetComponent<Collider2D>(), GetComponent<Collider2D>());
			}
		}
		
	}
}
