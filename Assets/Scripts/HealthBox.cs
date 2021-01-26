using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBox : MonoBehaviour
{
    public GameObject GUI = null;
    private void OnTriggerEnter(Collider Player)
    {
        GUI.GetComponent<myGUI>().Add();
        
        Destroy(gameObject);
    }
}


