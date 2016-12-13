using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public float delay;
    public GameObject canvas;
    public GameStats controller;

    private struct textLine
    {
        public string textString;
        public float timing;
    }

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
        dream1();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.getRecipe() != null && controller.getRecipe().Value.cooked == true)
        {
            if (controller.getRecipe().Value.cookingMethod == 1)
            {
                if (controller.getRecipe().Value.failure == 0)
                {
                    controller.addHunger(40f);
                    successfulBowlCereal();
                }
            }
        }
    }

    IEnumerator bobWantsPorrage()
    {
        //yield return new WaitForSeconds(3f);
        GameObject newObject;
        newObject = GameObject.Instantiate(canvas);
        controller.startDialogue();
        newObject.GetComponent<Panel>().setText("Porrage sounds good to Bob. Nothing can go wrong with porrage right?");
        for (int i = 0; controller.getDialogue() && i < 10; i++)
        {
            yield return new WaitForSeconds(0.5f * i);
        }
        GameObject.Destroy(newObject);
        controller.killDialogue();
    }

    void dream1()
    {
        //yield return new WaitForSeconds(3f);
        //GameObject newObject;
        //newObject = GameObject.Instantiate(canvas);
        //controller.startDialogue();
        //newObject.GetComponent<Panel>().setText("Bob awakens from his slumber glad to be free of the nightmareish hellscape he had dreamed. ");
        //for (int i = 0; controller.getDialogue() && i < 11; i++)
        //{
        //    yield return new WaitForSeconds(0.5f * i);
        //}
        //GameObject.Destroy(newObject);
        //controller.killDialogue();

        //newObject = GameObject.Instantiate(canvas);
        //controller.startDialogue();
        //newObject.GetComponent<Panel>().setText("Infested with terrorfying monsters which sometimes resembled hs mother, or his mother resembled some of the monsters. ");
        //for (int i = 0; controller.getDialogue() && i < 12; i++)
        //{
        //    yield return new WaitForSeconds(0.5f * i);
        //}
        //GameObject.Destroy(newObject);
        //controller.killDialogue();

        //newObject = GameObject.Instantiate(canvas);
        //controller.startDialogue();
        //newObject.GetComponent<Panel>().setText("He was not exactly sure which was which. However he was sure he'd never tell her that.");
        //for (int i = 0; controller.getDialogue() && i < 14; i++)
        //{
        //    yield return new WaitForSeconds(0.5f * i);
        //}
        //GameObject.Destroy(newObject);
        //controller.killDialogue();

        textLine[] textList = new textLine[3];

        textList[0] = new textLine { textString = "Bob awakens from his slumber glad to be free of the nightmareish hellscape he had dreamed.", timing = 5.5f };
        textList[1] = new textLine { textString = "Infested with terrorfying monsters which sometimes resembled hs mother, or his mother resembled some of the monsters.", timing = 6f };
        textList[2] = new textLine { textString = "He was not exactly sure which was which. However he was sure he'd never tell her that.", timing = 7f };

        StartCoroutine(displayText(textList, true, 2f));
    }

    void dream2()
    {
        //yield return new WaitForSeconds(3f);
        //GameObject newObject;
        //newObject = GameObject.Instantiate(canvas);
        //controller.startDialogue();
        //newObject.GetComponent<Panel>().setText("\"Remember Bob, you must remember this.The fate of the world is in your...\" the voice's words faded as Bob's eyelids fluttered open. ");
        //for (int i = 0; controller.getDialogue() && i < 10; i++)
        //{
        //    yield return new WaitForSeconds(0.5f * i);
        //}
        //GameObject.Destroy(newObject);
        //controller.killDialogue();

        //newObject = GameObject.Instantiate(canvas);
        //controller.startDialogue();
        //newObject.GetComponent<Panel>().setText("He tried his hardest dedicating a whole 2 brain cells to the activity (a personal record for Bob) but could not recall the rest of his dream.");
        //for (int i = 0; controller.getDialogue() && i < 10; i++)
        //{
        //    yield return new WaitForSeconds(0.5f * i);
        //}
        //GameObject.Destroy(newObject);
        //controller.killDialogue();

        //newObject = GameObject.Instantiate(canvas);
        //controller.startDialogue();
        //newObject.GetComponent<Panel>().setText("It'll probably be fine Bob thought. He had a similar dream a couple months ago which only resulted in a minor Zombie apocalypse.");
        //for (int i = 0; controller.getDialogue() && i < 10; i++)
        //{
        //    yield return new WaitForSeconds(0.5f * i);
        //}
        //GameObject.Destroy(newObject);
        //controller.killDialogue();

        //newObject = GameObject.Instantiate(canvas);
        //controller.startDialogue();
        //newObject.GetComponent<Panel>().setText("Nothing to lose sleep over.");
        //for (int i = 0; controller.getDialogue() && i < 10; i++)
        //{
        //    yield return new WaitForSeconds(0.5f * i);
        //}
        //GameObject.Destroy(newObject);
        //controller.killDialogue();

        textLine[] textList = new textLine[4];

        textList[0] = new textLine { textString = "\"Remember Bob, you must remember this.The fate of the world is in your...\" the voice's words faded as Bob's eyelids fluttered open.", timing = 5f};
        textList[1] = new textLine { textString = "He tried his hardest dedicating a whole 2 brain cells to the activity (a personal record for Bob) but could not recall the rest of his dream.", timing = 5f };
        textList[2] = new textLine { textString = "It'll probably be fine Bob thought. He had a similar dream a couple months ago which only resulted in a minor Zombie apocalypse.", timing = 5f };
        textList[3] = new textLine { textString = "Nothing to lose sleep over.", timing = 5f };

        StartCoroutine(displayText(textList, true, 3f));
    }

    void successfulBowlCereal()
    {
        textLine[] textList = new textLine[1];
        textList[0] = new textLine { textString = "The cereal was bland and uninteresting much like most of Bob's existience.", timing = 3f };
        StartCoroutine(displayText(textList));
    }

    IEnumerator displayText(textLine[] textList, bool startWait = false, float startWaitTime = 0f)
    {
        if (startWait)
        {
            yield return new WaitForSeconds(startWaitTime);
        }

        GameObject newObject;
        foreach (textLine textBlock in textList)
        {
            newObject = Instantiate(canvas);
            controller.startDialogue();
            newObject.GetComponent<Panel>().setText(textBlock.textString);
            for (int i = 0; controller.getDialogue() && i < (textBlock.timing/delay); i++)
            {
                yield return new WaitForSeconds(delay);
            }
            Destroy(newObject);
            controller.killDialogue();
        }
    }
}
