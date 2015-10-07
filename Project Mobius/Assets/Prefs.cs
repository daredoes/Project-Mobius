using UnityEngine;
using System.Collections;

public class Prefs : MonoBehaviour
{
    public static Prefs playerPrefs;
    public bool single;
    public bool local;
    public bool online;
	public bool demoMode;
    
    void Awake()
    {
        playerPrefs = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void Single()
    {
        single = true;
    }

    public void Online()
    {
        online = true;
    }

    public void LocalMult()
    {
        online = true;
    }

	public void DemoMode()
	{
		demoMode = true;
	}
}
