using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class TestStopRotatingGarden : MonoBehaviour, IInputClickHandler
{

    public void OnInputClicked(InputClickedEventData eventData)
    {
        GameObject gameObject = GameObject.Find("Garden");
        gameObject.GetComponent<Garden>().StopRotateGarden();
        Debug.Log("stoping to rotate garden!");
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
