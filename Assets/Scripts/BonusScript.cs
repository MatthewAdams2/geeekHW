using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusScript : MonoBehaviour
{
    [SerializeField] Vector3 cameraInitialPosition;
    [SerializeField] public float shakeMagnetude = 0.05f, shakeTime = 0.5f;
    [SerializeField] public Camera mainCamera;

    delegate void MyEventHandlerShake();

    class MyEvent
    {
        public event MyEventHandlerShake ShakeEvent;

        public void OnShakeEvent()
        {
            if (ShakeEvent != null)
                ShakeEvent();
        }
    }

    static void Handler()
    {
        Debug.Log("Камера тряслась!");
    }

    private void OnTriggerEnter(Collider other)
    {
        ShakeIt();
    }
    public void ShakeIt()
    {
        cameraInitialPosition = mainCamera.transform.position;
        InvokeRepeating("StartCameraShaking", 0f, 0.005f);
        Invoke("StopCameraShaking", shakeTime);
    }

    void StartCameraShaking()
    {
        float cameraShakingOffsetX = Random.value * shakeMagnetude * 2 - shakeMagnetude;
        float cameraShakingOffsetY = Random.value * shakeMagnetude * 2 - shakeMagnetude;
        Vector3 cameraIntermadiatePosition = mainCamera.transform.position;
        cameraIntermadiatePosition.x += cameraShakingOffsetX;
        cameraIntermadiatePosition.y += cameraShakingOffsetY;
        mainCamera.transform.position = cameraIntermadiatePosition;
    }

    void StopCameraShaking()
    {
        CancelInvoke("StartCameraShaking");
        mainCamera.transform.position = cameraInitialPosition;
       
        MyEvent evt = new MyEvent();

        evt.ShakeEvent += Handler;
        evt.OnShakeEvent();

        Destroy(this.gameObject);
    }

}

