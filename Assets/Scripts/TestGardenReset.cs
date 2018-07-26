using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class TestGardenReset : MonoBehaviour, IInputClickHandler
{
    public void OnInputClicked(InputClickedEventData eventData)
    {
        GameObject gameObject = GameObject.Find("Watering");
        gameObject.GetComponent<Watering>().ResetAll();
        Debug.Log("reset water!");

        GameObject gameObject1 = GameObject.Find("Garden");
        gameObject1.GetComponent<Garden>().ResetAll();
        Debug.Log("reset garden!");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
