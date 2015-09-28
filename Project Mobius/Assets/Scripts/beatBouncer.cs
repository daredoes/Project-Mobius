using UnityEngine;
using System.Collections;

public class beatBouncer : MonoBehaviour
{
	//flip = -1 (Moves down) flip = 1 (Moves up)
	[Range(-1, 1)]
	public int flip;
    private float fadeSpeed = 0.075f;
	private float distance = 1.0f;
    private bool fadeInColor = false;
	public bool p1;
	public bool moving;
	private Collider2D matchedBeat = null;
	bool hollow;
	private static float speed = .05f;
	//Higher = Faster, Lower = Slower
	private static float returnSpeedModifier = 1.5f;
    Color c;
    SpriteRenderer sprender;
	public Vector2 startPosition;
    public GameObject parentalUnit;
	// Use this for initialization
	void Start ()
	{
        gameObject.tag = "Floor";
        sprender = GetComponent<SpriteRenderer>();
        c = new Color(sprender.color.r, sprender.color.g, sprender.color.b, 0.0f);
		moving = false;
		hollow = true;
        if (p1)
        {
            flip = 1;
        }
        else
        {
            flip = -1;
        }

	}

	void Awake(){
		startPosition = transform.position;
	}

	public void spawned(){
        if (p1)
        {
            flip = 1;
        }
        else
        {
            flip = -1;
        }
        //Debug.Log(parentalUnit.transform.position);
        startPosition = transform.position;
        //transform.position = startPosition;
		distance = Mathf.Abs(GameManager.gm.centerPos.y - startPosition.y);
	}

	public bool isAtStart ()
	{
		return (Vector2)gameObject.transform.position == (Vector2)startPosition;
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (fadeInColor)
        {
            fadeIn();
        }
        if(sprender.color.a >= 255.0f)
        {
            fadeInColor = false;
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
            else
            {
                if(sprender.color.a != 0.0f)
                {
                    sprender.color = c;
                }
                else
                {
                    fadeOut();
                }
                /*
                if(sprender.enabled != false)
                {
                    sprender.enabled = false;
                } */
            }
		}
	
	}

    void fadeIn()
    {
        if(sprender.color.a < 255.0f)
        {
            sprender.color = new Color(c.r, c.g, c.b, sprender.color.a + fadeSpeed);
        }
    }
    
    void fadeOut()
    {
        if(sprender.color.a > 0.0f)
        {
            sprender.color = new Color(c.r, c.g, c.b, sprender.color.a - fadeSpeed);
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
				other.gameObject.GetComponent<beat_init>().bounce();
                moving = false;
			}
			else{
				Physics2D.IgnoreCollision(other.transform.GetComponent<Collider2D>(), GetComponent<Collider2D>());
			}
		}
	}

    public void hit()
    {
        if(!moving)
        { 
                if (isAtStart())
                {
                    fadeInColor = true;
                    moving = true;
                    hollow = false;
                    Physics2D.IgnoreCollision(matchedBeat, GetComponent<Collider2D>(), false);
                }
            

        }
        
    }
}
