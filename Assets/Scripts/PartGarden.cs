using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class PartGarden : MonoBehaviour, IInputClickHandler
{
    public GameObject prefab;
    private static bool isPartZoomed;
	// Use this for initialization
	void Start ()
    {
        isPartZoomed = false;
	}

    public void OnInputClicked(InputClickedEventData eventData)
    {
        isPartZoomed = !isPartZoomed;
        if( isPartZoomed )
        {
            GameObject selectedPart;
            Vector3 pos = new Vector3(0.4F, 0.2F, 1.7F);
            selectedPart = Instantiate(prefab, pos, Quaternion.identity);
            selectedPart.transform.localScale = new Vector3(0.7F, 0.7F, 0.7F);
        }

       
    }
}
