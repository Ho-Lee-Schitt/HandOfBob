using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    public GameStats GameStat;
    private GameObject gameTime, hungerText, happyText, socialText, TiredText;

    // Use this for initialization
    void Start () {
        if (GameStat == null)
        {
            GameStat = (GameStats)GameObject.Find("GameController").GetComponent(typeof(GameStats));
        }

        gameTime = transform.Find("Game Time").gameObject;
        hungerText = transform.Find("Hunger Stat").gameObject;
        happyText = transform.Find("Happy Stat").gameObject;
        socialText = transform.Find("Social Stat").gameObject;
        TiredText = transform.Find("Sleep Stat").gameObject;

        gameTime.GetComponent<Text>().text = "Day " + GameStat.getDay() + " - " + GameStat.getCurrentTime().ToString("h:MM tt");

    }
	
	// Update is called once per frame
	void Update () {
        gameTime.GetComponent<Text>().text = "Day " + GameStat.getDay() + " - " + GameStat.getCurrentTime().ToString("h:mm tt");
        hungerText.GetComponent<Text>().text = "Hunger: " + GameStat.getHungerValue().ToString("F0") + "%";
        happyText.GetComponent<Text>().text = "Happiness: " + GameStat.getHappinessValue().ToString("F0") + "%";
        socialText.GetComponent<Text>().text = "Social: " + GameStat.getSocialValue().ToString("F0") + "%";
        TiredText.GetComponent<Text>().text = "Tiredness: " + GameStat.getTirednessValue().ToString("F0") + "%";
    }
}
