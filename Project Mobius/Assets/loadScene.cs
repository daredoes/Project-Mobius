using UnityEngine;
using System.Collections;

public class loadScene : MonoBehaviour {

   // public string Scene;
    public void LoadAScene(string Scene)
    {
        Application.LoadLevel(Scene);

    }
}
