using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIController : MonoBehaviour {

    public GameObject UIStats;

	// Use this for initialization
	void Start () {
        GameObject.Instantiate(UIStats);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
