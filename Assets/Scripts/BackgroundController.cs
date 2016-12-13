using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

    public GameStats controller;

    private GameObject[] backgrounds;

	// Use this for initialization
	void Start () {
        backgrounds = new GameObject[transform.childCount];
	    for (int i = 0; i < transform.childCount; i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
        }
	}

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (controller.getBackground() == i)
            {
                backgrounds[i].GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                backgrounds[i].GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}
