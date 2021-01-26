using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myGUI : MonoBehaviour
{
    public int lives = 3;
    private float hSliderValue = 100.0f;

    public GUISkin livesboardSkin;

    public void Add()
    {
        Debug.Log("Прибавили 1");
        lives++;
    }

    void OnGUI()
    {
        GUI.skin = livesboardSkin;
        GUI.Label(new Rect(10, 10, 300, 100), "Health: " + lives);
    }
}
