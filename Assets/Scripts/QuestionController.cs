using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour {

    public Canvas screenCanvas;

    private Text questionText;
    private Button yesButton, noButton, IDKButton;

    private int level;
    private bool firstYes;

	// Use this for initialization
	void Start () {
        questionText = screenCanvas.transform.FindChild("Question").GetComponent<Text>();
        yesButton = screenCanvas.transform.FindChild("YesButton").GetComponent<Button>();
        noButton = screenCanvas.transform.FindChild("NoButton").GetComponent<Button>();
        IDKButton = screenCanvas.transform.FindChild("GameButton").GetComponent<Button>();

        level = 0;

        questionText.text = "This game uses spoken narration. Do you wish to hear it?";

        IDKButton.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void yesIsClicked()
    {
        if (level == 0)
        {
            questionText.text = "Are you sure the choice you've made is not what you absolutely don't want to do?";
            PlayerPrefs.SetInt("Narration", 1);

            IDKButton.gameObject.SetActive(true);

            yesButton.GetComponentInChildren<Text>().text = "Yes?...";
            noButton.GetComponentInChildren<Text>().text = "Wait what?";

            level++;
            firstYes = true;
        }
        else if (firstYes == true)
        {
            questionText.text = "Awesome. Well here we go!";
            yesButton.gameObject.SetActive(false);
            noButton.gameObject.SetActive(false);
            IDKButton.gameObject.SetActive(false);
            StartCoroutine(waitMethod(3));
        }
        else
        {
            PlayerPrefs.SetInt("Narration", 0);
            questionText.text = "I feel sad inside.";
            yesButton.gameObject.SetActive(false);
            noButton.gameObject.SetActive(false);
            IDKButton.gameObject.SetActive(false);
            StartCoroutine(waitMethod(3));
        }
    }

    public void noIsClicked()
    {
        if (level == 0)
        {
            questionText.text = "So you're telling me you wish to ignore something I spent many hours working on?";
            PlayerPrefs.SetInt("Narration", 0);

            yesButton.GetComponentInChildren<Text>().text = "Yes and I don't care.";
            yesButton.GetComponentInChildren<Text>().fontSize = 40;
            noButton.GetComponentInChildren<Text>().text = "Ok play your sound.";
            noButton.GetComponentInChildren<Text>().fontSize = 40;

            level++;
            firstYes = false;
        }
        else if (firstYes == true)
        {
            questionText.text = "Yeah I'm about as confused as you. Lets just move past that.";
            yesButton.gameObject.SetActive(false);
            noButton.gameObject.SetActive(false);
            IDKButton.gameObject.SetActive(false);
            StartCoroutine(waitMethod(4));
        }
        else
        {
            questionText.text = "Oh you do care!";
            PlayerPrefs.SetInt("Narration", 1);
            yesButton.gameObject.SetActive(false);
            noButton.gameObject.SetActive(false);
            IDKButton.gameObject.SetActive(false);
            StartCoroutine(waitMethod(3));
        }
    }

    public void IDKIsClicked()
    {
        questionText.text = "Sure! You're the boss!";
        PlayerPrefs.SetInt("Narration", 1);
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        IDKButton.gameObject.SetActive(false);
        StartCoroutine(waitMethod(3));
    }

    IEnumerator waitMethod(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        PlayerPrefs.Save();
        SceneManager.LoadScene("TitleScene");
    }
}
