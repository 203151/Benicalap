using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class TestStartRoratingGarden : MonoBehaviour, IInputClickHandler
{
    public void OnInputClicked(InputClickedEventData eventData)
    {
        GameObject gameObject = GameObject.Find("Garden");
        gameObject.GetComponent<Garden>().StartRotateGarden();
        Debug.Log("starting to rotate garden!");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
