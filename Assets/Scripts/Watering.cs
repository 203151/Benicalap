using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watering : MonoBehaviour
{
    private bool isVisible;
    private TextToSpeech textToSpeech;
    private Garden garden;
    // Use this for initialization
    void Start()
    {
        isVisible = false;
        garden = GameObject.Find("Garden").GetComponent<Garden>();
        textToSpeech = GameObject.Find("Audio Manager").GetComponent<TextToSpeech>();
    }

    public void ResetAll()
    {
        TurnOffVisibility();
    }

    public void ToggleWater()
    {
        if(textToSpeech.IsSpeaking())
        {
            textToSpeech.StopSpeaking();
        }
        else
        {
            TellMeMore();
        }

        ToggleVisibility();
    }

    void ToggleVisibility()
    {
        foreach ( Transform child in transform )
        {
            if(isVisible)
            {
                child.gameObject.SetActive(false);
                garden.SetTransparency(1);
            }
            else
            {
                child.gameObject.SetActive(true);
                garden.SetTransparency(0.2F);
            }
        }
        isVisible = !isVisible;
    }

    void TurnOffVisibility()
    {
        foreach ( Transform child in transform )
        {
            child.gameObject.SetActive(false);
            //child is your child transform
        }
       
    }

    public void StopVoice()
    {
        if(textToSpeech.IsSpeaking())
        {
            textToSpeech.StopSpeaking();
        }
    }

    public void TellMeMore()
    {
        string text = "Here you can see the watering system of our allotment garden. We will have three zones of different watering level, so you can plant vegetables and plants which varies in water consumption. Whole system is automated, so plants are watered in the most optimal time.";
       textToSpeech.StartSpeaking(text);
       textToSpeech.StopSpeaking();
       
    }

}
