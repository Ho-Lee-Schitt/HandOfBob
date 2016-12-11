using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameStats : MonoBehaviour {

    public int rateOfTime;
    public double rateOfHunger, rateOfHappiness, rateOfSocial, rateOfTiredness;

    private DateTime startTime;
    private DateTime currentTime;
    private DateTime lastTime;
    private double hunger;
    private double happiness;
    private double social;
    private double tiredness;
    private int duration;
    private int day;

    // Use this for initialization
    void Start () {
        double gameTimeInSeconds = DateTime.Now.TimeOfDay.TotalSeconds;

        TimeSpan convertedTime = TimeSpan.FromSeconds(gameTimeInSeconds * rateOfTime);

        convertedTime = convertedTime.Subtract(TimeSpan.FromDays(convertedTime.Days));

        startTime = new DateTime(2016, 1, 1) + convertedTime;

        hunger = 100;
        happiness = 100;
        social = 100;
        tiredness = 100;

        lastTime = startTime;
        currentTime = startTime;

        day = 1;

        //gameTime.GetComponent<Text>().text = "Time: " + gameClock.ToShortTimeString();
    }
	
	// Update is called once per frame
	void Update () {
        DateTime difference = getGameClock();
        if (currentTime.Hour == 23 && currentTime.Minute == 59)
        {
            Debug.Log("");
        }
        currentTime = difference;

        if ((currentTime.TimeOfDay - lastTime.TimeOfDay).TotalSeconds < 0)
        {
            day++;
        }

        double reduction = getHunger();
        if ((hunger - reduction) > 0)
        {
            hunger -= reduction;
        }
        reduction = getHappiness();
        if ((happiness - reduction) > 0)
        {
            happiness -= reduction;
        }
        reduction = getSocial();
        if ((social - reduction) > 0)
        {
            social -= reduction;
        }
        reduction = getTiredness();
        if ((tiredness - reduction) > 0)
        {
            tiredness -= reduction;
        }

        lastTime = currentTime;

        // Debug.Log(gameClock.TimeOfDay.ToString());
	}

    DateTime getGameClock()
    {
        double gameTimeInSeconds = DateTime.Now.TimeOfDay.TotalSeconds;

        TimeSpan convertedTime = TimeSpan.FromSeconds(gameTimeInSeconds * rateOfTime);
        convertedTime = convertedTime.Subtract(TimeSpan.FromDays(convertedTime.Days));

        DateTime gameClock = new DateTime(2016, 1, 1) + convertedTime;

        return gameClock;
    }

    //DateTime convertTime(DateTime dt_toBeConvrted)
    //{
    //    double totalSeconds = dt_toBeConvrted.TimeOfDay.TotalSeconds;
    //}

    double getHunger()
    {
        double hungerValue = 100 / (rateOfHunger * 60);
        //Debug.Log("Hunger Value " + hungerValue);

        return (hungerValue * (Time.deltaTime * rateOfTime));
    }

    double getHappiness()
    {
        double happinessValue = 100 / (rateOfHappiness * 60);
        //Debug.Log("Hunger Value " + happinessValue);

        return (happinessValue * (Time.deltaTime * rateOfTime));
    }

    double getSocial()
    {
        double socialValue = 100 / (rateOfSocial * 60);
        //Debug.Log("Hunger Value " + hungerValue);

        return (socialValue * (Time.deltaTime * rateOfTime));
    }

    double getTiredness()
    {
        double tirednessValue = 100 / (rateOfTiredness * 60);
        //Debug.Log("Hunger Value " + hungerValue);

        return (tirednessValue * (Time.deltaTime * rateOfTime));
    }

    public int getDay()
    {
        return day;
    }

    public DateTime getCurrentTime()
    {
        return currentTime;
    }

    public double getHungerValue()
    {
        return hunger;
    }

    public double getHappinessValue()
    {
        return happiness;
    }
    public double getSocialValue()
    {
        return social;
    }
    public double getTirednessValue()
    {
        return tiredness;
    }
}
