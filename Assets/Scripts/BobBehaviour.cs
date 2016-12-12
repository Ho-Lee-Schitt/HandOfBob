using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobBehaviour : MonoBehaviour
{

    public float speed;

    private float lastTime;
    private float deltaTime;
    private int moveTime;
    Vector2 destination;
    float journeyLength;


    // Use this for initialization
    void Start()
    {
        lastTime = Time.time;
        deltaTime = 0;
        moveTime = 0;
        destination.Set(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        System.Random rnd = new System.Random();
        if (moveTime == 0)
        {
            moveTime = rnd.Next(15, 30);
            Debug.Log("Wait time is: " + moveTime);
        }

        deltaTime = Time.time - lastTime;

        if (deltaTime > moveTime && destination == new Vector2(0, 0))
        {
            // Bob is going to move
            Debug.Log("Bob should move");

            destination = new Vector2((transform.position.x + rnd.Next(-8, 8)), transform.position.y);

            if (destination.x > 26f || destination.x < -22f)
            {
                moveTime = 0;
                lastTime = Time.time;
                destination.Set(0, 0);
                return;
            }

            journeyLength = Vector2.Distance((Vector2)transform.position, destination);

            Debug.Log("Position = " + destination.x + " " + destination.y);
        }



        if (destination != new Vector2(0,0))
        {
            float distanceCovered = (Time.time - lastTime) * speed;

            float fractionJourney = distanceCovered / journeyLength;

            transform.position = Vector2.Lerp(transform.position, destination, fractionJourney);

            if ((Vector2)transform.position == destination)
            {
                moveTime = 0;
                lastTime = Time.time;
                destination.Set(0, 0);
            }
        }

    }
}
