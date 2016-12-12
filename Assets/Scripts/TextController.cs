using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{

    public GameObject canvas;

    // Use this for initialization
    void Start()
    {
        System.Random rnd = new System.Random();

        int choice = rnd.Next(1, 4);
        switch (choice)
        {
            case 1:
                choice = rnd.Next(1, 2);
                switch (choice)
                {
                    case 1:
                        //StartCoroutine(dream1());
                        break;
                    case 2:
                        //StartCoroutine(dream2());
                        break;
                    default:
                        break;
                }
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            default:
                break;
        }
        StartCoroutine(dream2());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator bobWantsPorrage()
    {
        yield return new WaitForSeconds(3f);
        GameObject newObject;
        newObject = GameObject.Instantiate(canvas);
        newObject.GetComponent<Panel>().setText("Porrage sounds good to Bob. Nothing can go wrong with porrage right?");
        yield return new WaitForSeconds(5f);
        GameObject.Destroy(newObject);
    }

    IEnumerator dream1()
    {
        yield return new WaitForSeconds(3f);
        GameObject newObject;
        newObject = GameObject.Instantiate(canvas);
        newObject.GetComponent<Panel>().setText("Bob awakens from his slumber glad to be free of the nightmareish hellscape he had dreamed. ");
        yield return new WaitForSeconds(5.5f);
        GameObject.Destroy(newObject);
        newObject = GameObject.Instantiate(canvas);
        newObject.GetComponent<Panel>().setText("Infested with terrorfying monsters which sometimes resembled hs mother, or his mother resembled some of the monsters. "); 
        yield return new WaitForSeconds(6f);
        GameObject.Destroy(newObject);
        newObject = GameObject.Instantiate(canvas);
        newObject.GetComponent<Panel>().setText("He was not exactly sure which was which. However he was sure he'd never tell her that.");
        yield return new WaitForSeconds(7f);
        GameObject.Destroy(newObject);
    }

    IEnumerator dream2()
    {
        yield return new WaitForSeconds(3f);
        GameObject newObject;
        newObject = GameObject.Instantiate(canvas);
        newObject.GetComponent<Panel>().setText("\"Remember Bob, you must remember this.The fate of the world is in your...\" the voice's words faded as Bob's eyelids fluttered open. "); 
        yield return new WaitForSeconds(5f);
        GameObject.Destroy(newObject);

        newObject = GameObject.Instantiate(canvas);
        newObject.GetComponent<Panel>().setText("He tried his hardest dedicating a whole 2 brain cells to the activity (a personal record for Bob) but could not recall the rest of his dream.");
        yield return new WaitForSeconds(5f);
        GameObject.Destroy(newObject);

        newObject = GameObject.Instantiate(canvas);
        newObject.GetComponent<Panel>().setText("It'll probably be fine Bob thought. He had a similar dream a couple months ago which only resulted in a minor Zombie apocalypse.");
        yield return new WaitForSeconds(5f);
        GameObject.Destroy(newObject);

        newObject = GameObject.Instantiate(canvas);
        newObject.GetComponent<Panel>().setText("Nothing to lose sleep over.");
        yield return new WaitForSeconds(5f);
        GameObject.Destroy(newObject);
    }

}
