using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
// Reference the Unity Analytics namespace
using UnityEngine.Analytics;

public class GameStats : MonoBehaviour
{

    public int rateOfTime;
    public double rateOfHunger, rateOfHappiness, rateOfSocial, rateOfTiredness;

    public GameObject interactions;
    public GameObject ingrediants;

    private DateTime startTime;
    private DateTime currentTime;
    private DateTime lastTime;
    private double hunger;
    private double happiness;
    private double social;
    private double tiredness;
    private int duration;
    private int day;
    private int background;
    cookingWith currentMethod;

    private bool dialogue;



    enum cookingWith
    {
        nothing = 0, bowl, cooker, toaster
    }

    public struct recipeStruct
    {
        public int ingrediantCount { get; set; }
        public string[] ingrediants { get; set; }
        public int cookingMethod { get; set; }
        public int failure { get; set; }
        public bool cooked { get; set; }
    }

    Nullable<recipeStruct> currentRecipe;

    // Use this for initialization
    void Start()
    {
        double gameTimeInSeconds = DateTime.Now.TimeOfDay.TotalSeconds;

        TimeSpan convertedTime = TimeSpan.FromSeconds(gameTimeInSeconds * rateOfTime);

        convertedTime = convertedTime.Subtract(TimeSpan.FromDays(convertedTime.Days));

        startTime = new DateTime(2016, 1, 1) + convertedTime;

        hunger = 50;
        happiness = 100;
        social = 100;
        tiredness = 100;

        lastTime = startTime;
        currentTime = startTime;
        currentMethod = cookingWith.nothing;

        day = 1;
        background = 0;
        dialogue = false;

        currentRecipe = null;

        //gameTime.GetComponent<Text>().text = "Time: " + gameClock.ToShortTimeString();
    }

    // Update is called once per frame
    void Update()
    {
        DateTime difference = getGameClock();
        if (currentTime.Hour == 23 && currentTime.Minute == 59)
        {
            Debug.Log("");
        }
        currentTime = difference;

        if ((currentTime.TimeOfDay - lastTime.TimeOfDay).TotalSeconds < 0)
        {
            day++;
        }

        if (currentRecipe != null)
        {
            if ((currentRecipe.Value.cookingMethod == (int)cookingWith.bowl && currentRecipe.Value.ingrediantCount == 2) || (currentRecipe.Value.cookingMethod == (int)cookingWith.cooker && currentRecipe.Value.ingrediantCount == 1) || (currentRecipe.Value.cookingMethod == (int)cookingWith.toaster && currentRecipe.Value.ingrediantCount == 1))
            {
                ingrediants.SetActive(false);
                interactions.SetActive(true);
                background = 0;
                makeRecipe();
                if (currentRecipe.Value.ingrediantCount == 2)
                {
                    Analytics.CustomEvent("MadeFood", new Dictionary<string, object>
                    {
                        { "Ingrediant Count", currentRecipe.Value.ingrediantCount },
                        { "Cooking Method", currentRecipe.Value.cookingMethod },
                        { "Ingrediant 1", currentRecipe.Value.ingrediants[0] },
                        { "Ingrediant 2", currentRecipe.Value.ingrediants[1] },
                        { "Hunger", hunger },
                        { "Happiness", happiness },
                        { "Social", social },
                        { "Tiredness", tiredness },
                        { "Day", day }
                    });
                }
                else
                {
                    Analytics.CustomEvent("MadeFood", new Dictionary<string, object>
                    {
                        { "Ingrediant Count", currentRecipe.Value.ingrediantCount },
                        { "Cooking Method", currentRecipe.Value.cookingMethod },
                        { "Ingrediant 1", currentRecipe.Value.ingrediants[0] },
                        { "Hunger", hunger },
                        { "Happiness", happiness },
                        { "Social", social },
                        { "Tiredness", tiredness },
                        { "Day", day }
                    });
                }
            }
        }

        double reduction = getHunger();
        hunger = ((hunger - reduction) > 0) ? (hunger - reduction) : 0;

        reduction = getHappiness();
        happiness = ((happiness - reduction) > 0) ? (happiness - reduction) : 0;

        reduction = getSocial();
        social = ((social - reduction) > 0) ? (social - reduction) : 0;

        reduction = getTiredness();
        tiredness = ((tiredness - reduction) > 0) ? (tiredness - reduction) : 0;

        lastTime = currentTime;

        if (hunger == 0 || happiness == 0 || tiredness == 0 || social == 0 || hunger < 20 || happiness < 20 || tiredness < 20 || social < 20)
        {
            Analytics.CustomEvent("statZero", new Dictionary<string, object>
            {
                { "Hunger", hunger },
                { "Happiness", happiness },
                { "Social", social },
                { "Tiredness", tiredness },
                { "Day", day }
            });
        }

        // Debug.Log(gameClock.TimeOfDay.ToString());
    }

    DateTime getGameClock()
    {
        double gameTimeInSeconds = DateTime.Now.TimeOfDay.TotalSeconds;

        TimeSpan convertedTime = TimeSpan.FromSeconds(gameTimeInSeconds * rateOfTime);
        convertedTime = convertedTime.Subtract(TimeSpan.FromDays(convertedTime.Days));

        DateTime gameClock = new DateTime(2016, 1, 1) + convertedTime;

        return gameClock;
    }

    //DateTime convertTime(DateTime dt_toBeConvrted)
    //{
    //    double totalSeconds = dt_toBeConvrted.TimeOfDay.TotalSeconds;
    //}

    double getHunger()
    {
        double hungerValue = 100 / (rateOfHunger * 60);
        //Debug.Log("Hunger Value " + hungerValue);

        return (hungerValue * (Time.deltaTime * rateOfTime));
    }

    double getHappiness()
    {
        double happinessValue = 100 / (rateOfHappiness * 60);
        //Debug.Log("Hunger Value " + happinessValue);

        return (happinessValue * (Time.deltaTime * rateOfTime));
    }

    double getSocial()
    {
        double socialValue = 100 / (rateOfSocial * 60);
        //Debug.Log("Hunger Value " + hungerValue);

        return (socialValue * (Time.deltaTime * rateOfTime));
    }

    double getTiredness()
    {
        double tirednessValue = 100 / (rateOfTiredness * 60);
        //Debug.Log("Hunger Value " + hungerValue);

        return (tirednessValue * (Time.deltaTime * rateOfTime));
    }

    public int getDay()
    {
        return day;
    }

    public DateTime getCurrentTime()
    {
        return currentTime;
    }

    public double getHungerValue()
    {
        return hunger;
    }

    public double getHappinessValue()
    {
        return happiness;
    }
    public double getSocialValue()
    {
        return social;
    }
    public double getTirednessValue()
    {
        return tiredness;
    }

    public bool getDialogue()
    {
        return dialogue;
    }

    public void startDialogue()
    {
        if (!dialogue)
        {
            dialogue = true;
        }
    }

    public void killDialogue()
    {
        if (dialogue)
        {
            dialogue = false;
        }
    }

    public int getBackground()
    {
        return background;
    }

    public void interactionSelected(string name)
    {
        if (String.Compare(name, "Bowl") == 0)
        {
            background = 1;
            currentMethod = cookingWith.bowl;

            ingrediants.SetActive(true);
            interactions.SetActive(false);
        }
        else if (String.Compare(name, "Toaster") == 0)
        {
            background = 1;
            currentMethod = cookingWith.toaster;

            ingrediants.SetActive(true);
            interactions.SetActive(false);
        }
        else if (String.Compare(name, "Cooker") == 0)
        {
            background = 1;
            currentMethod = cookingWith.cooker;

            ingrediants.SetActive(true);
            interactions.SetActive(false);
        }
        else if (String.Compare(name, "PlayVG") == 0)
        {
            currentRecipe = new recipeStruct { ingrediants = new string[1] { name }, ingrediantCount = 1, cookingMethod = 0, failure = 0, cooked = true };
        }
        else if (String.Compare(name, "PetCat") == 0)
        {
            currentRecipe = new recipeStruct { ingrediants = new string[1] { name }, ingrediantCount = 1, cookingMethod = 0, failure = 0, cooked = true };
        }
        else
        {

        }
    }

    public void addIngrediant(string ingrediantName)
    {
        switch (currentMethod)
        {
            case cookingWith.nothing:
                break;
            case cookingWith.bowl:
                if (currentRecipe == null)
                {
                    currentRecipe = new recipeStruct { ingrediants = new string[2], ingrediantCount = 1, cookingMethod = (int)currentMethod, cooked = false };
                    currentRecipe.Value.ingrediants[0] = ingrediantName;
                }
                else
                {
                    recipeStruct newRecipe = new recipeStruct { ingrediants = new string[2], ingrediantCount = 2, cookingMethod = (int)currentMethod, cooked = false };
                    newRecipe.ingrediants[0] = currentRecipe.Value.ingrediants[0];
                    newRecipe.ingrediants[1] = ingrediantName;

                    currentRecipe = newRecipe;
                }
                break;
            case cookingWith.cooker:
                if (currentRecipe == null)
                {
                    currentRecipe = new recipeStruct { ingrediants = new string[1], ingrediantCount = 1, cookingMethod = (int)currentMethod, cooked = false };
                    currentRecipe.Value.ingrediants[0] = ingrediantName;
                }
                break;
            case cookingWith.toaster:
                if (currentRecipe == null)
                {
                    currentRecipe = new recipeStruct { ingrediants = new string[1], ingrediantCount = 1, cookingMethod = (int)currentMethod, cooked = false };
                    currentRecipe.Value.ingrediants[0] = ingrediantName;
                }
                break;
            default:
                break;
        }
    }

    private void makeRecipe()
    {
        if (currentRecipe.Value.cookingMethod == (int)cookingWith.bowl)
        {
            if ((currentRecipe.Value.ingrediants[0] == "Milk" && currentRecipe.Value.ingrediants[1] == "Cereal") || (currentRecipe.Value.ingrediants[1] == "Milk" && currentRecipe.Value.ingrediants[0] == "Cereal"))
            {
                currentRecipe = new recipeStruct { ingrediants = new string[2] { currentRecipe.Value.ingrediants[0], currentRecipe.Value.ingrediants[1] }, ingrediantCount = 2, cookingMethod = (int)currentRecipe.Value.cookingMethod, failure = 0, cooked = true };
            }
            else if ((currentRecipe.Value.ingrediants[0] == "Milk" && currentRecipe.Value.ingrediants[1] == "Milk") || (currentRecipe.Value.ingrediants[1] == "Milk" && currentRecipe.Value.ingrediants[0] == "Milk"))
            {
                currentRecipe = new recipeStruct { ingrediants = new string[2] { currentRecipe.Value.ingrediants[0], currentRecipe.Value.ingrediants[1] }, ingrediantCount = 2, cookingMethod = (int)currentRecipe.Value.cookingMethod, failure = 1, cooked = true };
            }
            else if ((currentRecipe.Value.ingrediants[0] == "Cereal" && currentRecipe.Value.ingrediants[1] == "Cereal") || (currentRecipe.Value.ingrediants[1] == "Cereal" && currentRecipe.Value.ingrediants[0] == "Cereal"))
            {
                currentRecipe = new recipeStruct { ingrediants = new string[2] { currentRecipe.Value.ingrediants[0], currentRecipe.Value.ingrediants[1] }, ingrediantCount = 2, cookingMethod = (int)currentRecipe.Value.cookingMethod, failure = 2, cooked = true };
            }
            else if ((currentRecipe.Value.ingrediants[0] == "Milk" && (currentRecipe.Value.ingrediants[1] == "Chicken" || currentRecipe.Value.ingrediants[1] == "Chips" || currentRecipe.Value.ingrediants[1] == "Ham")) || (currentRecipe.Value.ingrediants[1] == "Milk" && (currentRecipe.Value.ingrediants[0] == "Chicken" || currentRecipe.Value.ingrediants[0] == "Chips" || currentRecipe.Value.ingrediants[0] == "Ham")))
            {
                currentRecipe = new recipeStruct { ingrediants = new string[2] { currentRecipe.Value.ingrediants[0], currentRecipe.Value.ingrediants[1] }, ingrediantCount = 2, cookingMethod = (int)currentRecipe.Value.cookingMethod, failure = 3, cooked = true };
            }
            else if ((currentRecipe.Value.ingrediants[0] == "Milk" && currentRecipe.Value.ingrediants[1] == "Porridge") || (currentRecipe.Value.ingrediants[1] == "Milk" && currentRecipe.Value.ingrediants[0] == "Porridge"))
            {
                currentRecipe = new recipeStruct { ingrediants = new string[2] { currentRecipe.Value.ingrediants[0], currentRecipe.Value.ingrediants[1] }, ingrediantCount = 2, cookingMethod = (int)currentRecipe.Value.cookingMethod, failure = 4, cooked = true };
            }
            else
            {
                currentRecipe = new recipeStruct { ingrediants = new string[2] { currentRecipe.Value.ingrediants[0], currentRecipe.Value.ingrediants[1] }, ingrediantCount = 2, cookingMethod = (int)currentRecipe.Value.cookingMethod, failure = 5, cooked = true };
            }
        }
        if (currentRecipe.Value.cookingMethod == (int)cookingWith.toaster)
        {
            if (currentRecipe.Value.ingrediants[0] == "Bread")
            {
                currentRecipe = new recipeStruct { ingrediants = new string[1] { currentRecipe.Value.ingrediants[0] }, ingrediantCount = 1, cookingMethod = (int)currentRecipe.Value.cookingMethod, failure = 0, cooked = true };
            }
            else if (currentRecipe.Value.ingrediants[0] == "Milk")
            {
                currentRecipe = new recipeStruct { ingrediants = new string[1] { currentRecipe.Value.ingrediants[0] }, ingrediantCount = 1, cookingMethod = (int)currentRecipe.Value.cookingMethod, failure = 1, cooked = true };
            }
            else if (currentRecipe.Value.ingrediants[0] == "Cereal" || currentRecipe.Value.ingrediants[0] == "Porridge")
            {
                currentRecipe = new recipeStruct { ingrediants = new string[1] { currentRecipe.Value.ingrediants[0] }, ingrediantCount = 1, cookingMethod = (int)currentRecipe.Value.cookingMethod, failure = 2, cooked = true };
            }
            else
            {
                currentRecipe = new recipeStruct { ingrediants = new string[1] { currentRecipe.Value.ingrediants[0] }, ingrediantCount = 1, cookingMethod = (int)currentRecipe.Value.cookingMethod, failure = 3, cooked = true };
            }
        }
        if (currentRecipe.Value.cookingMethod == (int)cookingWith.cooker)
        {
            if (currentRecipe.Value.ingrediants[0] == "Porridge")
            {
                currentRecipe = new recipeStruct { ingrediants = new string[1] { currentRecipe.Value.ingrediants[0] }, ingrediantCount = 1, cookingMethod = (int)currentRecipe.Value.cookingMethod, failure = 0, cooked = true };
            }
            else if (currentRecipe.Value.ingrediants[0] == "Milk")
            {
                currentRecipe = new recipeStruct { ingrediants = new string[1] { currentRecipe.Value.ingrediants[0] }, ingrediantCount = 1, cookingMethod = (int)currentRecipe.Value.cookingMethod, failure = 1, cooked = true };
            }
            else if (currentRecipe.Value.ingrediants[0] == "Bread")
            {
                currentRecipe = new recipeStruct { ingrediants = new string[1] { currentRecipe.Value.ingrediants[0] }, ingrediantCount = 1, cookingMethod = (int)currentRecipe.Value.cookingMethod, failure = 2, cooked = true };
            }
            else
            {
                currentRecipe = new recipeStruct { ingrediants = new string[1] { currentRecipe.Value.ingrediants[0] }, ingrediantCount = 1, cookingMethod = (int)currentRecipe.Value.cookingMethod, failure = 3, cooked = true };
            }
        }
    }

    public void addHunger(float value)
    {
        if (value >= 0)
        {
            hunger = ((hunger + value) < 100f) ? (hunger + value) : 100f;
        }
        else
        {
            hunger = ((hunger + value) > 0) ? (hunger + value) : 0f;
        }

        currentRecipe = null;
    }

    public void addFun(float value)
    {
        if (value >= 0)
        {
            happiness = ((happiness + value) < 100f) ? (happiness + value) : 100f;
        }
        else
        {
            happiness = ((happiness + value) > 0) ? (happiness + value) : 0f;
        }

        currentRecipe = null;
    }

    public void addSocial(float value)
    {
        if (value >= 0)
        {
            social = ((social + value) < 100f) ? (social + value) : 100f;
        }
        else
        {
            social = ((social + value) > 0) ? (social + value) : 0f;
        }

        currentRecipe = null;
    }

    public recipeStruct? getRecipe()
    {
        return currentRecipe;
    }
}
