using UnityEngine;
using System.Collections;

public class mainManager : MonoBehaviour
{
    public GameObject modeSelectPanel;

    void Awake()
    {
        modeSelectPanel.SetActive(false);
    }

    public void Play()
    {
        modeSelectPanel.SetActive(true);
    }
}
