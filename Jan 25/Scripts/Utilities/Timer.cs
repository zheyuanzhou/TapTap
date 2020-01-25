using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System;

public class Timer : MonoBehaviour
{
    private Text timerText;
    [HideInInspector] public float timer;

    private void Start()
    {
        timerText = GetComponent<Text>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        UpdateText();
    }

    private void UpdateText()
    {
        float seconds = Mathf.Floor(timer % 60);
        float mins = Mathf.Floor((timer % 3600) / 60);
        float hours = Mathf.Floor((timer % 216000) / 3600);

        timerText.text = hours.ToString("00") + ":" + mins.ToString("00") + ":" + seconds.ToString("00");
    }

    //MARKER Display Current Real Time

    //private void Update()
    //{
    //    DateTime time = DateTime.Now;
    //    string hr = LeadingZero(time.Hour);
    //    string min = LeadingZero(time.Minute);
    //    string second = LeadingZero(time.Second);
    //    timerText.text = hr + ":" + min + ":" + second;
    //}

    //string LeadingZero(int _time)
    //{
    //    return _time.ToString().PadLeft(2, '0');
    //}

}
