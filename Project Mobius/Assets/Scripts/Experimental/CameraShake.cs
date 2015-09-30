using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

    public Camera mainCamera;
    float shakeAmount = 0;

    void Awake()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    public void Shake(float amount, float length)
    {
        shakeAmount = amount;
        InvokeRepeating("BeginShake", 0, 0.01f);
        Invoke("StopShake", length);
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.T))
        {
            Shake(0.1f, 0.5f);
        }
    }

    void BeginShake()
    {
        if (shakeAmount >0)
        {
            Vector3 camPos = mainCamera.transform.position;

            float offSetX = Random.value * shakeAmount * 2 - shakeAmount;
            float offSetY = Random.value * shakeAmount * 2 - shakeAmount;

            camPos.x += offSetX;
            camPos.y += offSetY;

            mainCamera.transform.position = camPos;
        }
    }

    void StopShake()
    {
        CancelInvoke("BeginShake");
        mainCamera.transform.localPosition = Vector3.zero;
    }
}
