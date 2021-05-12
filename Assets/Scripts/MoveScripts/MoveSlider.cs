using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveSlider : MonoBehaviour
{

    public Slider sliderInstance;
    public float speed = 400;
    public float timeS;
    bool move;

    private void Update()
    {
        move = FindObjectOfType<GameManager>().stopTime;
        if (move) 
        {
            timeS = Time.time * speed;
            sliderInstance.minValue = 0;
            sliderInstance.maxValue = 100;
            sliderInstance.wholeNumbers = true;
            choice();
        }    
    }

    public void OnValueChanged(float value) 
    {
        Debug.Log("New Value" + value);
    }
    public void choice() 
    {
        sliderInstance.value = Mathf.PingPong(timeS, sliderInstance.maxValue);
    }
}
