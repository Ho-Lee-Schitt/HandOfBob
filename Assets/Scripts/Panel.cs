using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour {

    private string text;
    private Text textBox;

    // Use this for initialization
    void Start () {
        //float height = Camera.main.orthographicSize * 2;
        //float width = height * Screen.width / Screen.height; // basically height * screen aspect ratio
        textBox = GetComponentInChildren<Text>();
        textBox.text = "";
        ////panel1.transform.localScale = new Vector3(width / 3f, height/ 3f, 0);

        //Canvas canvas = GetComponent<Canvas>();

        //Debug.Log("Scene Height " + Screen.height + " Screen width " + Screen.width);

        //if (Camera.main.aspect >= 1.7)
        //{
        //    Debug.Log("16:9");
        //    textBox.text = "16:9" + " Scene Height " + Screen.height + " Screen width " + Screen.width + "\nCanvas Size " + canvas.pixelRect.width + " x " + canvas.pixelRect.height;
        //}
        //else if (Camera.main.aspect >= 1.5)
        //{
        //    Debug.Log("3:2");
        //    textBox.text = "3:2";
        //}
        //else
        //{
        //    Debug.Log("4:3");
        //    textBox.text = "4:3";
        //}

        //Image bg = GetComponentInChildren<Image>();

        // bg.rectTransform

    }
	
	// Update is called once per frame
	void Update () {
        //if (Camera.main.aspect >= 1.7)
        //{
        //    // Debug.Log("16:9");
        //    textBox.text = "16:9" + " Scene Height " + Screen.height + " Screen width " + Screen.width + "\nTime: " + Time.time.ToString("#");
        //}
        //else if (Camera.main.aspect >= 1.5)
        //{
        //    Debug.Log("3:2");
        //    textBox.text = "3:2";
        //}
        //else
        //{
        //    Debug.Log("4:3");
        //    textBox.text = "4:3";
        //}

        textBox.text = text;
        //textBox.color = new Color(textBox.color.r, textBox.color.g, textBox.color.b, 0.5f);
    }

    public void setText(string textString)
    {
        text = textString;
    }
}
