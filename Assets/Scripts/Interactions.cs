using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour {

    GameObject cat;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0)
        {
            Vector2 test = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            RaycastHit2D hit = Physics2D.Raycast(test, Input.GetTouch(0).position);

            if (hit.collider && hit.collider.name == "PetCat")
            {
                cat = gameObject.transform.FindChild("PetCat").gameObject;
                cat.GetComponent<SpriteRenderer>().enabled = false;
            } 
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 test = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(test, Camera.main.transform.forward);

            if (hit.collider && hit.collider.name == "PetCat")
            {
                cat = gameObject.transform.FindChild("PetCat").gameObject;
                cat.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
	}
}
