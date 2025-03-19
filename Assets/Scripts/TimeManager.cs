using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private static int hoursInDay;
    private static int minutesInHour;
    [SerializeField] private float dayDuration;
    [SerializeField] private float startTime;
    [SerializeField] private float speed;
    private static float currentTime;
    private static float savedTime;
    public static string result;

    void Start()
    {
        hoursInDay = 24;
        minutesInHour = 60;
        if (savedTime != 0)
        {
            startTime = savedTime;
        }
        else
        {
            startTime *= speed;
        }
        dayDuration *= speed;
    }

    void Update()
    {
        startTime += Time.deltaTime;
        currentTime = startTime % dayDuration;
    }

    public float GetHour()
    {
        return Mathf.FloorToInt(currentTime * hoursInDay / dayDuration);
    }

    public float GetMinutes()
    {
        return Mathf.FloorToInt((currentTime * hoursInDay * minutesInHour / dayDuration) % minutesInHour);
    }

    public string Clock24Hour()
    {
        return GetHour().ToString("00") + ":" + GetMinutes().ToString("00");
    }

    public void SaveTime()
    {
        savedTime = startTime;
    }
}
