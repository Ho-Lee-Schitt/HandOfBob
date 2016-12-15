using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narration : MonoBehaviour {

    public GameStats controller;

    AudioSource dream1, dream2, quote1, quote2, quote3, action1, action2, action3, breakfast, makeCereal, makePorridge, makeToast;

    void Start()
    {
        dream1 = transform.FindChild("dream1").GetComponent<AudioSource>();
        dream2 = transform.FindChild("dream2").GetComponent<AudioSource>();
        quote1 = transform.FindChild("quote1").GetComponent<AudioSource>();
        quote2 = transform.FindChild("quote2").GetComponent<AudioSource>();
        quote3 = transform.FindChild("quote3").GetComponent<AudioSource>();
        action1 = transform.FindChild("action1").GetComponent<AudioSource>();
        action2 = transform.FindChild("action2").GetComponent<AudioSource>();
        action3 = transform.FindChild("action3").GetComponent<AudioSource>();
        breakfast = transform.FindChild("breakfast").GetComponent<AudioSource>();
        makeCereal = transform.FindChild("makeCereal").GetComponent<AudioSource>();
        makePorridge = transform.FindChild("makePorridge").GetComponent<AudioSource>();
        makeToast = transform.FindChild("makeToast").GetComponent<AudioSource>();
    }

    public int playDream1()
    {
        if (controller.useVoices())
        {
            dream1.Play();
        }
        return 0;
    }

    public int playDream2()
    {
        if (controller.useVoices())
        {
            dream2.Play();
        }
        return 0;
    }

    public int playQuote1()
    {
        if (controller.useVoices())
        {
            quote1.Play();
        }
        return 0;
    }

    public int playQuote2()
    {
        if (controller.useVoices())
        {
            quote2.Play();
        }
        return 0;
    }

    public int playQuote3()
    {
        if (controller.useVoices())
        {
            quote3.Play();
        }
        return 0;
    }

    public int playAction1()
    {
        if (controller.useVoices())
        {
            action1.Play();
        }
        return 0;
    }

    public int playAction2()
    {
        if (controller.useVoices())
        {
            action2.Play();
        }
        return 0;
    }

    public int playAction3()
    {
        if (controller.useVoices())
        {
            action3.Play();
        }
        return 0;
    }

    public int playMakeProoidge()
    {
        if (controller.useVoices())
        {
            makePorridge.Play();
        }
        return 0;
    }

    public int playBreakfast()
    {
        if (controller.useVoices())
        {
            breakfast.Play();
        }
        return 0;
    }

    public int playMakeCereal()
    {
        if (controller.useVoices())
        {
            makeCereal.Play();
        }
        return 0;
    }

    public int playMakeToast()
    {
        if (controller.useVoices())
        {
            makeToast.Play();
        }
        return 0;
    }
}
