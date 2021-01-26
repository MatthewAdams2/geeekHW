using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myGUIBox : MonoBehaviour
{
    private float mySlider = 1.0f;
    public Color myColor;
    public MeshRenderer GO;

    [ContextMenu("Рандомные значения")]
    private void MyRandom()
    {
        myColor.r = Random.Range(0.0f, 5.0f);
        myColor.g = Random.Range(0.0f, 5.0f);
        myColor.b = Random.Range(0.0f, 5.0f);
    }

    //Задаем начальные значения MinValue
    private void Start()
    {
        myColor.r = Random.Range(0.0f, 1.0f);
        myColor.g = Random.Range(0.0f, 1.0f);
        myColor.b = Random.Range(0.0f, 1.0f);
    }

    private void OnGUI()
    {
        mySlider = LabelSlider(new Rect(10, 80, 200, 20), mySlider, 5.0f, "My Slider");
        myColor = RGBSlider(new Rect(10, 100, 200, 20), myColor);
        GO.material.color = myColor;
    }

    float LabelSlider(Rect screenRect, float sliderValue, float sliderMaxValue, string labelText)
    {
        Rect labelRect = new Rect(screenRect.x, screenRect.y, screenRect.width / 2, screenRect.height);
        GUI.Label(labelRect, labelText);
        Rect sliderRect = new Rect(screenRect.x + screenRect.width / 2, screenRect.y, screenRect.width / 2, screenRect.height);
        sliderValue = GUI.HorizontalSlider(sliderRect, sliderValue, 0.0f, sliderMaxValue);
        return sliderValue;
    }

    Color RGBSlider(Rect screenRect, Color rgb)
    {
        rgb.r = LabelSlider(screenRect, rgb.r, 1.0f, "Red");

        screenRect.y += 20;
        rgb.g = LabelSlider(screenRect, rgb.g, 1.0f, "Green");

        screenRect.y += 20;
        rgb.b = LabelSlider(screenRect, rgb.b, 1.0f, "Blue");

        screenRect.y += 20;
        rgb.a = LabelSlider(screenRect, rgb.a, 1.0f, "alpha");

        return rgb;
    }
}
