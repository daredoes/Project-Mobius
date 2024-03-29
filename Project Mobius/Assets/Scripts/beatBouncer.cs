using UnityEngine;
using System.Collections;

public class beatBouncer : playableObject
{
	//flip = -1 (Moves down) flip = 1 (Moves up)
	[Range(-1, 1)]
	public int flip;
    private float fadeSpeed = 0.075f;
	private float distance = 1.0f;
    private bool fadeInColor = false;
	public bool p1;
	public bool moving;
	public float scaler = 1.0f;
	private Collider2D matchedBeat = null;
	bool hollow;
	private static float speed = .05f;
	//Higher = Faster, Lower = Slower
	private static float returnSpeedModifier = 1.5f;
    Color c;
    SpriteRenderer sprender;
	public Vector2 startPosition;
   // public GameObject parentalUnit;
    public bool isai;
    public GameObject myBarBeat;

    public float distanceFromBeat;
    public float hitDistance = 1f;
    public bool AIhit;
    public float missProb;
	public int missRatio = 10;
	public float passRate = 0f;

	int countdown = 0;
	int timeoutTimer = 15;
	int timeoutRate = 1;

    void Awake()
    {
        startPosition = transform.position;
        
    }

    // Use this for initialization
    void Start ()
	{
        isai = GetComponentInParent<button>().isAI;
        myBarBeat = GetComponentInParent<button>().matchedBeat;
        //Debug.Log(myBarBeat);

        gameObject.tag = "Floor";
        sprender = GetComponent<SpriteRenderer>();
        c = new Color(sprender.color.r, sprender.color.g, sprender.color.b, 0.0f);
		moving = false;
		hollow = true;
		//Easy
		if (GameManager.gm.GetComponent<GameManager> ().difficulty == 0) {
			missRatio = 5;
			passRate = 0.75f;
		}
		//Medium
		else if(GameManager.gm.GetComponent<GameManager> ().difficulty == 1){
			missRatio = 7;
			passRate = 0.5f;

		}
		//Hard
		else if(GameManager.gm.GetComponent<GameManager> ().difficulty == 2){
			missRatio = 10;
			passRate = 0.25f;
		}

        if (p1)
        {
            flip = 1;
        }
        else
        {
            flip = -1;
        }

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
		hitDistance = distance;
	}

	public bool isAtStart ()
	{
		return (Vector2)gameObject.transform.position == (Vector2)startPosition;
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (activated) {
			if (isai) {
				distanceFromBeat = Mathf.Abs (transform.position.y - myBarBeat.transform.position.y);

				missProb = Random.Range (0f, 1f);
				//Debug.Log (countdown);
				if (countdown > 0) {
					countdown -= timeoutRate;
				}
				//Debug.Log (countdown);

				if (missProb > passRate && countdown == 0) {
					AIhit = true;
				} else if(countdown == 0) {
					AIhit = false;
					countdown = timeoutTimer;
				}

				if (distanceFromBeat < hitDistance && AIhit) {
					if (p1 && myBarBeat.GetComponent<beat_init> ().flip) {
						hit ();
					} else if (!p1 && !myBarBeat.GetComponent<beat_init> ().flip) {
						hit ();
					}
				}
			}

			if (fadeInColor) {
				fadeIn ();
			}
			if (sprender.color.a >= 255.0f) {
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
				} else {
					if (sprender.color.a != 0.0f) {
						sprender.color = c;
					} else {
						fadeOut ();
					}
					/*
                if(sprender.enabled != false)
                {
                    sprender.enabled = false;
                } */
				}
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
