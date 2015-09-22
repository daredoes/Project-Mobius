using UnityEngine;
using System.Collections;

public class settings : MonoBehaviour {
	public Hashtable p1Keys = new Hashtable();
	public Hashtable p2Keys = new Hashtable();
	// Use this for initialization
	void Start () {
	
	}

	void Awake()
	{
		setKeys ();	
	}
	void setKeys(){
		//Player 1 Keys
		p1Keys.Add ("Beat1Launch", KeyCode.A);
		p1Keys.Add ("Beat2Launch", KeyCode.S);
		p1Keys.Add ("Beat3Launch", KeyCode.D);
		p1Keys.Add ("Beat4Launch", KeyCode.F);
		p1Keys.Add ("Beat5Launch", KeyCode.G);

		//Player 2 Keys
		p2Keys.Add ("Beat1Launch", KeyCode.J);
		p2Keys.Add ("Beat2Launch", KeyCode.K);
		p2Keys.Add ("Beat3Launch", KeyCode.L);
		p2Keys.Add ("Beat4Launch", KeyCode.Semicolon);
		p2Keys.Add ("Beat5Launch", KeyCode.DoubleQuote);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
