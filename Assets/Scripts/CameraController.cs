using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    // Use this for initialization
    public float speed;
    public float panSpeed = 100;
    Vector3 panOrigin;

    // Update is called once per frame
    void Update () {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                if ((transform.position.x + (-touchDeltaPosition.x * speed * Time.deltaTime)) < -12.6)
                {
                    transform.TransformPoint(-13f, 0, transform.position.z);
                }
                else
                {
                    transform.Translate(-touchDeltaPosition.x * speed, 0, 0);
                }


            }


        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                panOrigin = Camera.main.ScreenToViewportPoint(Input.mousePosition);                    //Get the ScreenVector the mouse clicked
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition) - panOrigin;    //Get the difference between where the mouse clicked and where it moved
                //transform.position = new Vector3(oldPos.x + -pos.x * panSpeed, transform.position.y, transform.position.z);                                         //Move the position of the camera to simulate a drag, speed * 10 for screen to worldspace conversion
                transform.Translate(-pos.x * panSpeed, 0, 0);
            }

            if (Input.GetMouseButtonUp(0))
            {
            }
        }
    }
}
