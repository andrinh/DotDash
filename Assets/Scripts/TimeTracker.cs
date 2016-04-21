using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class TimeTracker : MonoBehaviour {

    public Text timeText;

    private static float gameTime;

    void FixedUpdate()
    {
        gameTime = Time.timeSinceLevelLoad; ;
        
        timeText.text = gameTime.ToString("0.00");
    }
}
