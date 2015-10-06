using UnityEngine;
using System.Collections;

public class beat_init : playableObject
{
    /*
     * UI Variables
	 */
    private float camShakeAmount = 0.02f;
    CameraShake camShake;
	Quaternion currentRotation;
	///////////////////////////////////////////////

	/*
	 * Data Variables
	 */
	public Color sideColor;
	[Range(0.0f, .2f)]
	public float step = .05f;
	public bool flip;
	bool moving;
	public float travelLength;
	Vector2 startPosition;
	///////////////////////////////////////////////

    // Use this for initialization
    void Start ()
	{

        //Camera shake stuff
        camShake = GameManager.gm.GetComponent<CameraShake>();

        gameObject.tag = "Beat";
		startPosition = gameObject.transform.position;
        currentRotation = gameObject.transform.rotation;
        currentRotation.z = 0;
        Vector2 temp = gameObject.transform.localScale;
        temp.x *= -1;
        gameObject.transform.localScale = temp;
		flip = false;
		moving = true;
	}
	// Update is called once per frame
	void Update ()
	{
        gameObject.transform.rotation = currentRotation;
        if (activated)
        {
            //Player 1 Side
            if (flip)
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
                camShake.Shake(camShakeAmount, 0.03f);
                // Player Two
                if (gameObject.transform.position.y < startPosition.y - travelLength)
                {
                    //Debug.Log("Should be scoring");
                    GameManager.gm.GetComponent<GameManager>().player2.GetComponent<player_main>().score += 1;
                }
                //Player One
                else if(gameObject.transform.position.y > startPosition.y + travelLength)
                {
                    GameManager.gm.GetComponent<GameManager>().player1.GetComponent<player_main>().score += 1;
                }
				bounce();
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
	
	}

	public void bounce ()
	{
		flip = !flip;
		Vector3 temp = gameObject.transform.localScale;
		temp.y *= -1;
        temp.x *= -1;
		gameObject.transform.localScale = temp;
	}

	public void spawned(){
		unpause ();
	}
}
	
