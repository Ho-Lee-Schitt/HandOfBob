using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    public void Start()
    {
        Analytics.CustomEvent("GameStart", new Dictionary<string, object>
        {
            { "Screen Width", Screen.width },
            { "Screen Height", Screen.height }
        });
    }

    public void buttonClick()
    {
        StartCoroutine(changeScene());
    }

    IEnumerator changeScene()
    {
        float fadeTime = GameObject.Find("GameObject").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene("Level");
    }
}
