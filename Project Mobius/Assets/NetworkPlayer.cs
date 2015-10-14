using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;

public class NetworkPlayer : NetworkBehaviour {
    Text hello;
    bool p1;
    bool spawned;

    void Awake()
    {
        hello = GameObject.FindGameObjectWithTag("hello").GetComponent<Text>();
        
    }

    void Start()
    {
        check();
    }

    void check()
    {
        if (isLocalPlayer)
        {
            if (isClient)
            {
                hello.text = "Running as a client (HOST)";
                PlayerOneSetUp();

            }
            else if (isServer)
            {
                hello.text = "Running as a server";
                PlayerTwoSetUp();
            }
            else
                hello.text = "neither";
        }
    }

    void PlayerOneSetUp()
    {
        p1 = true;
        //SET UP EVERYTHING THEN SET FINISHED SPAWNING VARIABLE TO TRUE
        transform.position = _NetworkGameManager.NGM.playerOneSpawnPoint.transform.position;
        transform.rotation = _NetworkGameManager.NGM.playerOneSpawnPoint.transform.rotation;
        spawned = true;
    }

    void PlayerTwoSetUp()
    {
        p1 = false;
        //SET UP EVERYTHING THEN SET FINISHED SPAWNING VARIABLE TO TRUE
        transform.position = _NetworkGameManager.NGM.playerTwoSpawnPoint.transform.position;
        transform.rotation = _NetworkGameManager.NGM.playerTwoSpawnPoint.transform.rotation;
        spawned = false;
    }
}
