using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public float delay;
    public GameObject canvas;
    public GameStats controller;
    public Narration narrition;

    private float currentDuration;

    private struct textLine
    {
        public string textString;
        public float timing;
    }

    // Use this for initialization
    void Start()
    {
        currentDuration = 3f;
        System.Random rnd = new System.Random();

        int choice = rnd.Next(1, 3);
        //int choice = 1;
        switch (choice)
        {
            case 1: // Dreams
                choice = rnd.Next(1, 2);
                //choice = 1;
                switch (choice)
                {
                    case 1:
                        dream1();
                        break;
                    case 2:
                        dream2();
                        break;
                    default:
                        break;
                }
                break;
            case 2: // Actions
                choice = rnd.Next(1, 2);
                switch (choice)
                {
                    case 1:
                        action1();
                        break;
                    case 2:
                        action2();
                        break;
                    default:
                        break;
                }
                break;
            case 3: // Quote
                choice = rnd.Next(1, 3);
                switch (choice)
                {
                    case 1:
                        quote1();
                        break;
                    case 2:
                        quote2();
                        break;
                    case 3:
                        quote3();
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }

        afterWake();
        choice = rnd.Next(1, 3);
        switch (choice)
        {
            case 1: // Dreams
                bobWantsPorridge();
                break;
            case 2: // Actions
                bobWantsCereal();
                break;
            case 3: // Quote
                bobWantsToast();
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.getRecipe() != null && controller.getRecipe().Value.cooked == true)
        {
            if (controller.getRecipe().Value.cookingMethod == 1)
            {
                if (controller.getRecipe().Value.failure == 3)
                {
                    if (controller.getRecipe().Value.ingrediants[0] == "Milk")
                    {
                        successfulBowlCereal(controller.getRecipe().Value.failure, controller.getRecipe().Value.ingrediants[1]);
                    }
                    else
                    {
                        successfulBowlCereal(controller.getRecipe().Value.failure, controller.getRecipe().Value.ingrediants[0]);
                    }
                }
                else
                {
                    successfulBowlCereal(controller.getRecipe().Value.failure, controller.getRecipe().Value.ingrediants[0]);
                }
            }
            else if (controller.getRecipe().Value.cookingMethod == 2)
            {
                successfulCooker(controller.getRecipe().Value.failure, controller.getRecipe().Value.ingrediants[0]);
            }
            else if (controller.getRecipe().Value.cookingMethod == 3)
            {
                successfulToaster(controller.getRecipe().Value.failure, controller.getRecipe().Value.ingrediants[0]);
            }
            else if (controller.getRecipe().Value.cookingMethod == 0)
            {
                if (controller.getRecipe().Value.ingrediants[0] == "PlayVG")
                {
                    playVideoGames();
                }
                else
                {
                    petCat();
                }
            }

        }
    }

    void dream1()
    {
        textLine[] textList = new textLine[3];

        textList[0] = new textLine { textString = "Bob awakens from his slumber glad to be free of the nightmarish hellscape he had dreamed.", timing = 5.6f };
        textList[1] = new textLine { textString = "Infested with terrifying monsters which sometimes resembled has mother, or his mother resembled some of the monsters.", timing = 6f };
        textList[2] = new textLine { textString = "He was not exactly sure which was which. However he was sure he'd never tell her that.", timing = 7f };

        for (int i = 0; i < textList.Length; i++)
        {
            currentDuration += textList[i].timing;
        }

        StartCoroutine(displayText(textList, true, 3f, narrition.playDream1));
    }

    void dream2()
    {
        textLine[] textList = new textLine[5];

        textList[0] = new textLine { textString = "\"Remember Bob, you must remember this. The fate of the world is in your...\" the voice's words faded as Bob's eyelids fluttered open.", timing = 10.5f };
        textList[1] = new textLine { textString = "He tried his hardest dedicating a whole two brain cells to the activity", timing = 4.5f };
        textList[2] = new textLine { textString = " (a personal record for Bob) but could not recall the rest of his dream.", timing = 4f };
        textList[3] = new textLine { textString = "It'll probably be fine Bob thought. He had a similar dream a couple months ago which only resulted in a minor Zombie apocalypse.", timing = 7f };
        textList[4] = new textLine { textString = "Nothing to lose sleep over.", timing = 2f };

        for (int i = 0; i < textList.Length; i++)
        {
            currentDuration += textList[i].timing;
        }

        StartCoroutine(displayText(textList, true, 3f, narrition.playDream2));
    }

    void action1()
    {
        textLine[] textList = new textLine[4];

        textList[0] = new textLine { textString = "Bob wondered why people didn't sleep on the floor more often. It was perfectly functional for all intents and purposes.", timing = 7.5f };
        textList[1] = new textLine { textString = "He didn't start there of course but he did seem to end up here sometimes after falling asleep in bed.", timing = 5.5f };
        textList[2] = new textLine { textString = "Some people would draw a conclusion, taking into account the bump on Bob's head, that would explain Bob's prediciment.", timing = 7f };
        textList[3] = new textLine { textString = "Unfortunatly for Bob, he can't draw.", timing = 3.2f };

        for (int i = 0; i < textList.Length; i++)
        {
            currentDuration += textList[i].timing;
        }

        StartCoroutine(displayText(textList, true, 3f, narrition.playAction1));
    }

    void action2()
    {
        textLine[] textList = new textLine[4];

        textList[0] = new textLine { textString = "Bob awoke ready to start a new day and by that I mean he was already dressed and his teeth brushed.", timing = 6f };
        textList[1] = new textLine { textString = "Unfortunatly a flamingo outfit isn't a costume you've unlocked yet so you'll have to change that.", timing = 6f };
        textList[2] = new textLine { textString = "Oh, oh dear. It seems Bob did indeed use a brush from the bathroom, just not the one for teeth.", timing = 8f };
        textList[3] = new textLine { textString = "It is nice when he tries though.", timing = 2f };

        for (int i = 0; i < textList.Length; i++)
        {
            currentDuration += textList[i].timing;
        }

        StartCoroutine(displayText(textList, true, 3f, narrition.playAction2));
    }

    void quote1()
    {
        textLine[] textList = new textLine[1];

        textList[0] = new textLine { textString = "Early to bed and early to rise is the mark of success, Bob wholeheartedly embracing this arose a little past 1pm.", timing = 7f };

        for (int i = 0; i < textList.Length; i++)
        {
            currentDuration += textList[i].timing;
        }

        StartCoroutine(displayText(textList, true, 3f, narrition.playQuote1));
    }
    void quote2()
    {
        textLine[] textList = new textLine[2];

        textList[0] = new textLine { textString = "Bob's mum always told him to Never give up.", timing = 2.5f };
        textList[1] = new textLine { textString = "He was not quite sure who Up was and what shouldn't he give them but some mornings this troubled him deeply.", timing = 8f };

        for (int i = 0; i < textList.Length; i++)
        {
            currentDuration += textList[i].timing;
        }

        StartCoroutine(displayText(textList, true, 3f, narrition.playQuote2));
    }

    void quote3()
    {
        textLine[] textList = new textLine[3];

        textList[0] = new textLine { textString = "Bob was always told to follow his dreams. Last night he drempt he was a microwave.", timing = 5.5f };
        textList[1] = new textLine { textString = "Since he'd been previously warned to stay away from utilities that produce radiation,", timing = 4.5f };
        textList[2] = new textLine { textString = "Bob thought it best to let this dream remain unfolllowed.", timing = 3f };

        for (int i = 0; i < textList.Length; i++)
        {
            currentDuration += textList[i].timing;
        }

        StartCoroutine(displayText(textList, true, 3f, narrition.playQuote3));
    }

    void successfulBowlCereal(int failure, string food)
    {
        textLine[] textList;
        textList = new textLine[1];
        switch (failure)
        {
            case 0:
                controller.addHunger(40f);
                textList = new textLine[1];
                textList[0] = new textLine { textString = "The cereal was bland and uninteresting much like most of Bob's existience.", timing = 3f };
                break;
            case 1:
                controller.addHunger(10f);
                textList = new textLine[1];
                textList[0] = new textLine { textString = "It's nice when cereal includes some actual cereal. Bob couldn't complain, after all who would listen?", timing = 3f };
                break;
            case 2:
                controller.addHunger(10f);
                textList = new textLine[1];
                textList[0] = new textLine { textString = "Milk would have been nice too.", timing = 3f };
                break;
            case 3:
                controller.addHunger(5f);
                textList = new textLine[2];
                textList[0] = new textLine { textString = food + " with milk wasn't exactly plesant. It made it all soggy and wet.", timing = 3f };
                textList[1] = new textLine { textString = "Bob understood at last why they weren't a typical breakfast combo.", timing = 3f };
                break;
            case 4:
                controller.addHunger(5f);
                textList = new textLine[1];
                textList[0] = new textLine { textString = "It was actually ok though Porridge should probably be cooked first.", timing = 3f };
                break;
            case 5:
                controller.addHunger(1f);
                textList = new textLine[1];
                textList[0] = new textLine { textString = "They worked ok but they weren't really what Bob was looking for.", timing = 3f };
                break;
            default:
                break;
        }



        StartCoroutine(displayText(textList));
    }

    void successfulToaster(int failure, string food)
    {
        textLine[] textList;
        textList = new textLine[1];
        switch (failure)
        {
            case 0:
                controller.addHunger(40f);
                textList = new textLine[1];
                textList[0] = new textLine { textString = "The toast was good. It looked, smelled and felt like toast. It also generally acted in the way toast does around people.", timing = 3f };
                break;
            case 1:
                controller.addHunger(10f);
                textList = new textLine[2];
                textList[0] = new textLine { textString = "Milk didn't really toast too well. Or rather it didn't toast at all.", timing = 3f };
                textList[1] = new textLine { textString = "It just sat there all over the counter probably questioning what kind of idiot thought it'd go well in a toaster.", timing = 3f };
                break;
            case 2:
                controller.addHunger(-10f);
                textList = new textLine[1];
                textList[0] = new textLine { textString = "Burnable stuff in the toaster is always a good idea since it tends to catch fire. Like it's doing now.", timing = 3f };
                break;
            case 3:
                controller.addHunger(0f);
                textList = new textLine[2];
                textList[0] = new textLine { textString = ("Thankfully " + food + " didn't really toast since it didn't really fit."), timing = 3f };
                textList[1] = new textLine { textString = "A good life lesson for Bob but still no breakfast.", timing = 3f };
                break;
            default:
                break;
        }
        StartCoroutine(displayText(textList));
    }

    void successfulCooker(int failure, string food)
    {
        textLine[] textList;
        textList = new textLine[1];
        switch (failure)
        {
            case 0:
                controller.addHunger(40f);
                textList = new textLine[1];
                textList[0] = new textLine { textString = "The porridge tasted just like the one his mother used to make. Terrible and full of passive aggressiveness.", timing = 3f };
                break;
            case 1:
                controller.addHunger(5f);
                textList = new textLine[0];
                textList[0] = new textLine { textString = "Milk is generally not very exciting. So it's no surprise once warmed doesn't really get any better.", timing = 3f };
                break;
            case 2:
                controller.addHunger(10f);
                textList = new textLine[1];
                textList[0] = new textLine { textString = "Well it's toast just not in the conventional method.", timing = 3f };
                break;
            case 3:
                controller.addHunger(0f);
                textList = new textLine[2];
                textList[0] = new textLine { textString = ("Typically when " + food + " is cooked, you include a few other ingrediants to give it some life."), timing = 3f };
                textList[1] = new textLine { textString = "Unfortunatly this meal is about as dead as Bob's social life.", timing = 3f };
                break;
            default:
                break;
        }
        StartCoroutine(displayText(textList));
    }

    void bobWantsPorridge()
    {
        textLine[] textList = new textLine[1];

        textList[0] = new textLine { textString = "Porridge sounds good to Bob. Nothing can go wrong with porridge right?", timing = 5f };

        StartCoroutine(displayText(textList, true, currentDuration + 3f, narrition.playMakeProoidge));
    }

    void bobWantsCereal()
    {
        textLine[] textList = new textLine[1];

        textList[0] = new textLine { textString = "Bob decides to prepare some cereal. He'll need both cereal and milk.", timing = 5f };

        StartCoroutine(displayText(textList, true, currentDuration + 3f, narrition.playMakeCereal));
    }

    void bobWantsToast()
    {
        textLine[] textList = new textLine[1];

        textList[0] = new textLine { textString = "Bob is going to have toast. For his own personal safety he is forbidden from actually toching the toaster.", timing = 6f };

        StartCoroutine(displayText(textList, true, currentDuration + 3f, narrition.playMakeToast));
    }

    void afterWake() // Waking, don't worry no one is dead
    {
        textLine[] textList = new textLine[1];

        textList[0] = new textLine { textString = "With Bob ready to face the new day he feels it's time for a spot of breakfast.", timing = 5f };

        StartCoroutine(displayText(textList, true, currentDuration + 2f, narrition.playBreakfast));

        for (int i = 0; i < textList.Length; i++)
        {
            currentDuration += textList[i].timing;
        }
    }

    void petCat()
    {
        System.Random rnd = new System.Random();

        int choice = rnd.Next(1, 3);
        textLine[] textList = new textLine[1];

        switch (choice)
        {
            case 1:
                controller.addSocial(20f);
                textList = new textLine[3];
                textList[0] = new textLine { textString = "As Bob reaches his hand out to pet his cat it hisses fiercely and claws at his hand.", timing = 5f };
                textList[1] = new textLine { textString = "Once again Bob feels happy from the warmth that come from a sharing a deep friendship with an animal.", timing = 5f };
                textList[2] = new textLine { textString = "The warmth was of course the blood oozing from the fresh cuts on his hand.", timing = 5f };
                break;
            case 2:
                controller.addSocial(30f);
                textList = new textLine[3];
                textList[0] = new textLine { textString = "The cat meowed back at Bob. Bob was positivity ecstatic.", timing = 5f };
                break;
            case 3:
                controller.addSocial(20f);
                textList = new textLine[3];
                textList[0] = new textLine { textString = "Bob tried multiple ways of greeting the cat, all of which fell on deaf ears.", timing = 5f };
                textList[1] = new textLine { textString = "His conversation was interrupted when he spotted a red dot on the floor which he decided to chase after.", timing = 5f };
                textList[2] = new textLine { textString = "Maybe it would talk to him.", timing = 5f };
                break;
            default:
                break;
        }

        StartCoroutine(displayText(textList, true, currentDuration + 3f));
    }

    void playVideoGames()
    {
        controller.addFun(20f);
        textLine[] textList = new textLine[3];
        textList[0] = new textLine { textString = "Bob settled into his chair and began playing the latest video game on the market.", timing = 5f };
        textList[1] = new textLine { textString = "What he doesn't understand is the game console he is playing with is a washing machine.", timing = 5f };
        textList[2] = new textLine { textString = "He even takes it out for a spin every now and again.", timing = 5f };

        StartCoroutine(displayText(textList, true, currentDuration + 3f));
    }

    IEnumerator displayText(textLine[] textList, bool startWait = false, float startWaitTime = 0f, Func<int> myMethod = null)
    {
        if (startWait)
        {
            yield return new WaitForSeconds(startWaitTime);
        }

        if (myMethod != null)
        {
            myMethod();
        }

        GameObject newObject;
        foreach (textLine textBlock in textList)
        {
            newObject = Instantiate(canvas);
            controller.startDialogue();
            newObject.GetComponent<Panel>().setText(textBlock.textString);
            for (int i = 0; controller.getDialogue() && i < (textBlock.timing / delay); i++)
            {
                yield return new WaitForSeconds(delay);
            }
            Destroy(newObject);
            controller.killDialogue();
        }
    }
}
