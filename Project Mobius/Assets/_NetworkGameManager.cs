using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class _NetworkGameManager : MonoBehaviour
{
    public static _NetworkGameManager NGM;
    public GameObject playerOneSpawnPoint;
    public GameObject playerTwoSpawnPoint;
    Vector2 vec1 = new Vector2(0, -1);
    Vector2 vec2 = new Vector2(0, 1);

	void Awake()
    {
        NGM = this;
        playerOneSpawnPoint.transform.position = vec1;
        playerTwoSpawnPoint.transform.position = vec2;
    }
}
