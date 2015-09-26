using UnityEngine;
using System.Collections;

public class beat_init : MonoBehaviour
{
	bool flip;
	bool moving;
    bool game_started = false;
	[Range(0.0f, 5.0f)]
	public static float
		travelLength = 1.0f;
	Vector2 startPosition;
	public Color sideColor;
	[Range(0.0f, .2f)]
	public float
		step = .05f;
	// Use this for initialization
	void Start ()
	{
		startPosition = gameObject.transform.position;

        Vector2 temp = gameObject.transform.localScale;
        temp.x *= -1;
        gameObject.transform.localScale = temp;
		flip = false;
		moving = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (game_started)
        {
            //Player 1 Side
            if (transform.position.y > startPosition.y)
            {
                sideColor = GameManager.gm.GetComponent<GameManager>().player1.gameObject.GetComponent<player_main>().color;

            }
            //Player 2 Side
            else
            {
                sideColor = GameManager.gm.GetComponent<GameManager>().player2.gameObject.GetComponent<player_main>().color;
            }
            gameObject.GetComponent<SpriteRenderer>().color = sideColor;
            if (gameObject.transform.position.y < startPosition.y - travelLength || gameObject.transform.position.y > startPosition.y + travelLength)
            {
                gameObject.transform.position = startPosition;
            }
            if (moving)
            {
                if (!flip)
                {
                    gameObject.transform.Translate(Vector2.up * step);
                }
                else
                {
                    gameObject.transform.Translate(Vector2.down * step);
                }
            }
        }
        /*
		if (Input.GetKeyDown (KeyCode.J)) {
			bounce ();
		}
		if (Input.GetKeyDown (KeyCode.K)) {
			moving = !moving;
		}
		if (Input.GetKeyDown (KeyCode.L)) {
			gameObject.transform.Translate (Vector2.up * step);
		} */

	
	}
    public void startGame()
    {
        game_started = true;
    }

	public void bounce ()
	{
		flip = !flip;
		Vector3 temp = gameObject.transform.localScale;
		temp.y *= -1;
        temp.x *= -1;
		gameObject.transform.localScale = temp;
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == ("Floor")) {
		}

	}
}
	
