using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Clock : MonoBehaviour
{
    [SerializeField] Transform hoursPivot, minutesPivot, secondsPivot;

    [SerializeField] bool smoothTick = true;

    const float hoursToDegrees = -30f;
    const float minutesToDegrees = -6f;
    const float secondsToDegrees = -6f;


    void Awake() {
        print(DateTime.Now);
    }

    void Update()
    {        
        if (smoothTick)
        {
            TimeSpan smoothTime = DateTime.Now.TimeOfDay;

            hoursPivot.localRotation = Quaternion.Euler(0, 0, hoursToDegrees * (float)smoothTime.TotalHours);
            minutesPivot.localRotation = Quaternion.Euler(0, 0, minutesToDegrees * (float)smoothTime.TotalMinutes);
            secondsPivot.localRotation = Quaternion.Euler(0, 0, secondsToDegrees * (float)smoothTime.TotalSeconds);
        }
        else
        {
            DateTime time = DateTime.Now;
            hoursPivot.localRotation = Quaternion.Euler(0, 0, hoursToDegrees * (float)time.TimeOfDay.TotalHours);
            minutesPivot.localRotation = Quaternion.Euler(0, 0, minutesToDegrees * time.Minute);
            secondsPivot.localRotation = Quaternion.Euler(0, 0, secondsToDegrees * time.Second);
        }
    }
}
