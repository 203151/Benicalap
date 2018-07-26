using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class TestShowHideWater : MonoBehaviour, IInputClickHandler
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnInputClicked(InputClickedEventData eventData)
    {
        GameObject gameObject = GameObject.Find("Watering");
        gameObject.GetComponent<Watering>().ToggleWater();
        Debug.Log("show/hide water!");
    }
}
