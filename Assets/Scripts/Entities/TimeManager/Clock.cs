using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // using text mesh for the clock display

public class Clock : MonoBehaviour
{
    public TextMeshProUGUI timeDisplay; // Display Time
    public TextMeshProUGUI dayDisplay; // Display Day
    public int startingHour = 8; // The hour to start the game at
    public int hoursPerDay = 24; // The number of hours in a day
    public int minutesPerHour = 60; // The number of minutes in an hour
    public int daysPerYear = 365; // The number of days in a year
    public float defaultTimeScale = 1f; // The default speed at which time passes

    private int currentHour; // The current hour of the day
    private int currentMinute; // The current minute of the hour
    private int currentDay; // The current day of the year
    private float timeElapsed; // The amount of time that has passed since the last minute
    private float timeScale = 10f; // The speed at which time is passing

    TimeManager timeManager;


    private void Start()
    {
        currentHour = startingHour;
        currentMinute = 0;
        currentDay = 1;
        timeElapsed = 0f;

        timeManager = this.GetComponent<TimeManager>();
    }

    private void Update()
    {
        DisplayTime();
        // Calculate the amount of time that has passed since the last frame and adjust for the time scale
        float deltaTime = Time.deltaTime * timeScale;

        // Add the elapsed time to the time accumulator
        timeElapsed += deltaTime;

        // If the elapsed time is greater than or equal to the length of a minute, update the time and reset the elapsed time
        if (timeElapsed >= 1f)
        {
            currentMinute++;
            timeElapsed -= 1f;

            // If we've reached the end of an hour, increment the hour and reset the minute
            if (currentMinute >= minutesPerHour)
            {
                currentMinute = 0;
                currentHour++;

                // If we've reached the end of a day, increment the day and reset the hour
                if (currentHour >= hoursPerDay)
                {
                    currentHour = 0;
                    currentDay++;
                    UpdateTimeManagerDay();

                    // If we've reached the end of a year, reset the day
                    if (currentDay > daysPerYear)
                    {
                        currentDay = 1;
                    }
                }
            }
        }
    }

    public void SetTimeScale(float newTimeScale)
    {
        timeScale = newTimeScale;
    }

    public int GetCurrentHour()
    {
        return currentHour;
    }

    public int GetCurrentMinute()
    {
        return currentMinute;
    }

    public int GetCurrentDay()
    {
        return currentDay;
    }

    public int GetCurrentDayTime()
    {
        return (currentHour * 60) + currentMinute;
    }

    public int GetActualHour()
    {
        int hour = currentHour;
        int minute = currentMinute;

        // Convert the hour and minute values to strings with leading zeros
        string hourString = hour.ToString().PadLeft(2, '0');
        string minuteString = minute.ToString().PadLeft(2, '0');

        // Concatenate the hour and minute strings and convert the result to an integer
        int actualHour = int.Parse(hourString + minuteString);

        return actualHour;
    }

    public void DisplayTime() // Shows time and day in ui
    {

        timeDisplay.text = string.Format("{0:00}:{1:00}", currentHour, currentMinute); // The formatting ensures that there will always be 0's in empty spaces
        dayDisplay.text = "Day: " + currentDay; // display day counter
    }

    private void UpdateTimeManagerDay()
    {
        timeManager.NewDay(currentDay);
    }
}