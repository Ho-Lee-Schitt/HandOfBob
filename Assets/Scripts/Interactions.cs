using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour {

    public GameStats controller;

    GameObject cat;

    Vector2?[] oldTouchPositions = {
        null,
        null
    };
    Vector2 oldTouchVector;
    float oldTouchDistance;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.touchCount == 1)
        {
            Touch tap = Input.touches[0];
            //foreach (Touch tap in Input.touches)
            if (tap.phase != TouchPhase.Began && tap.phase != TouchPhase.Moved)
            {
                if (tap.phase == TouchPhase.Ended)
                {
                    if (tap.tapCount == 1)
                    {
                        Vector2 test = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                        RaycastHit2D hit = Physics2D.Raycast(test, Input.GetTouch(0).position);

                        if (!controller.getDialogue())
                        {
                            if (hit.collider && hit.collider.name == "PetCat")
                            {
                                // Pet the cat
                                cat = GameObject.Find("PetCat").gameObject;
                                
                                if (cat.GetComponent<SpriteRenderer>().enabled)
                                {
                                    cat.GetComponent<SpriteRenderer>().enabled = false;
                                }
                                else
                                {
                                    cat.GetComponent<SpriteRenderer>().enabled = true;
                                }
                            }

                            if (hit.collider && hit.collider.name == "PlayVG")
                            {
                                // Play Video Games
                                cat = GameObject.Find("PlayVG").gameObject;
                                cat.GetComponent<SpriteRenderer>().enabled = false;
                            }

                            if (hit.collider && hit.collider.name == "Bowl")
                            {
                                // Bowl
                                controller.Bowl();
                            }

                            if (hit.collider && hit.collider.name == "Cooker")
                            {
                                // Cooker
                                //controller.Cooker();
                            }

                            if (hit.collider && hit.collider.name == "Toaster")
                            {
                                // Toaster
                                //controller.Toaster();
                            }

                            if (hit.collider && hit.collider.name == "Milk")
                            {
                                // Toaster
                                controller.addIngrediant("Milk");
                            }

                            if (hit.collider && hit.collider.name == "Ham")
                            {
                                // Toaster
                                controller.addIngrediant("Ham");
                            }

                            if (hit.collider && hit.collider.name == "Chicken")
                            {
                                // Toaster
                                controller.addIngrediant("Chicken");
                            }

                            if (hit.collider && hit.collider.name == "Chips")
                            {
                                // Toaster
                                controller.addIngrediant("Chips");
                            }

                            if (hit.collider && hit.collider.name == "Porrage")
                            {
                                // Toaster
                                controller.addIngrediant("Porrage");
                            }

                            if (hit.collider && hit.collider.name == "Cereal")
                            {
                                // Toaster
                                controller.addIngrediant("Cereal");
                            }

                            if (hit.collider && hit.collider.name == "Bread")
                            {
                                // Toaster
                                controller.addIngrediant("Bread");
                            }
                        }
                    }
                }
            }
        }


        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (controller.getDialogue())
        //    {
        //        controller.killDialogue();
        //    }

        //    Vector2 test = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    RaycastHit2D hit = Physics2D.Raycast(test, Camera.main.transform.forward);

        //    if (hit.collider && hit.collider.name == "PetCat")
        //    {
        //        cat = gameObject.transform.FindChild("PetCat").gameObject;
        //        cat.GetComponent<SpriteRenderer>().enabled = false;
        //    }
        //}

        if (Input.touchCount == 0)
        {
            oldTouchPositions[0] = null;
            oldTouchPositions[1] = null;
        }
        else
        {
            if (oldTouchPositions[0] == null || oldTouchPositions[1] != null)
            {
                oldTouchPositions[0] = Input.GetTouch(0).position;
                oldTouchPositions[1] = null;
            }
            else
            {
                Vector2 newTouchPosition = Input.GetTouch(0).position;

                Vector3 trans = (Vector3)((oldTouchPositions[0] - newTouchPosition) * Camera.main.orthographicSize / Camera.main.pixelHeight * 2f);
                trans.y = 0;

                if (trans.x > 0f)
                {
                    if (Camera.main.transform.position.x < 20f)
                    {
                        Camera.main.transform.position += Camera.main.transform.TransformDirection(trans);
                    }
                }
                else
                {
                    if (Camera.main.transform.position.x > -15f)
                    {
                        Camera.main.transform.position += Camera.main.transform.TransformDirection(trans);
                    }
                }

                oldTouchPositions[0] = newTouchPosition;
            }
        }

        //if (Input.touchCount == 1)
        //{
        //    if (Input.GetTouch(0).phase == TouchPhase.Moved)
        //    {
        //        Vector3 trans = (Vector3)((-Input.GetTouch(0).deltaPosition) * Camera.main.orthographicSize / Camera.main.pixelHeight); //* Camera.main.orthographicSize / Camera.main.pixelHeight * 2f);
        //        trans.y = 0;

        //        if (trans.x > 0f)
        //        {
        //            if (Camera.main.transform.position.x < 20f)
        //            {
        //                // Camera.main.transform.position += Camera.main.transform.TransformDirection(trans);
        //                Camera.main.transform.position += trans;
        //            }
        //        }
        //        else
        //        {
        //            if (Camera.main.transform.position.x > -15f)
        //            {
        //                //Camera.main.transform.position += Camera.main.transform.TransformDirection(trans);
        //                Camera.main.transform.position += trans;
        //            }
        //        }
        //    }
        //}

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
