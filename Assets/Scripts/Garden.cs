using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;

public class Garden : MonoBehaviour, IInputClickHandler
{
    private GameObject Part1Selected;
    private GameObject Part2Selected;
    private GameObject Part3Selected;
    private GameObject Part4Selected;

    private GameObject BasicGarden;
    private GameObject TransparentGarden;

    private TextToSpeech textToSpeech;

    private bool isGardenPlaced;
    private bool isGardenRotating;
    private int zoomedPart; // 0 - none is zoomed              +-----+-----+
                            // 1 - first part is zoomed        |  1  |  3  |
                            // 2 - second part is zoomed       +-----+-----+
                            // 3 - third part is zoomed        |  2  |  4  |
                            // 4 - fourth part is zoomed       +-----+-----+

    void Start ()
    {
        isGardenPlaced = false;
        isGardenRotating = false;
        zoomedPart = 0;
        Part1Selected = GameObject.Find("Part1 Selected");
        Part2Selected = GameObject.Find("Part2 Selected");
        Part3Selected = GameObject.Find("Part3 Selected");
        Part4Selected = GameObject.Find("Part4 Selected");

        BasicGarden = GameObject.Find("BasicGarden");
        TransparentGarden = GameObject.Find("TransparentGarden");

        Part1Selected.SetActive(false);
        Part2Selected.SetActive(false);
        Part3Selected.SetActive(false);
        Part4Selected.SetActive(false);

        textToSpeech = GameObject.Find("Audio Manager").GetComponent<TextToSpeech>();

        string text = "welcome in holographic allotment garden. In front of you you can see visualisation of our allotment garden. Now the garden is following your head, if you want to place it do the air tap gesture on it. You can use air tap gestures to select one part of a garden, you can grab the garden with two hands and scale it, rotate it and move it. You can also use voice commands to manipulate the garden such as: Start Rotation, Stop Rotation, Show water, Hide water, Tell me more, Stop Voice, Reset all.  Give it a try!";
        textToSpeech.StartSpeaking(text);
        textToSpeech.StopSpeaking();        
    }

	void Update ()
    {
		if(isGardenRotating)
        {
            foreach ( Transform child in transform )
            {
                child.transform.Rotate(0, 10 * Time.deltaTime, 0);
            }            
        }
	}

    public void TellMeMore()
    {
        string text;
        if (zoomedPart == 0)
        {
            text = "As you can see our garden consists of four parts: one BBQ place, where you can rest after hard work in the garden, have some family party or just relax. Then we have three parts of allotment garden, where you can grow your own vegetables! each part has different watering level, so you can have different plants in one place";
            textToSpeech.StartSpeaking(text);
            textToSpeech.StopSpeaking();            
        }
        else if (zoomedPart == 4)
        {
            text = "this is the smallest part of the garden. Here you can find 16 small plots, 25 square meters each. This part has the highest watering level, so you can grow here the most demanding plants here.";
            textToSpeech.StartSpeaking(text);
            textToSpeech.StopSpeaking();           
        }
        else if ( zoomedPart == 2 )
        {
            text = "This part consists of 20 big plots, 50 square meters each. The watering level is medium here. You can also find some benches to rest during work and lampposts to illuminate whole garden.";
            textToSpeech.StartSpeaking(text);
            textToSpeech.StopSpeaking();
        }
        else if ( zoomedPart == 1) //3
        {
            text = "This part consists of 20 big plots, 50 square meters each. The watering level is the lowest here. You can also find some benches to rest during work and lampposts to illuminate whole garden.";
            textToSpeech.StartSpeaking(text);
            textToSpeech.StopSpeaking();
        }
        else if ( zoomedPart == 3 ) //4
        {
            text = "this is entertaining zone, with BBQ spot. There is small building for gardening tools in the bottom left corner. In the top left corner there is our office, where you can find working staff, rent the plot and get help. In the middle we placed arbor, where you may have some party with friends and family, there are tables and benches around and of course there are BBQ";
            textToSpeech.StartSpeaking(text);
            textToSpeech.StopSpeaking();
        }
    }

    public void ResetAll()
    {
        isGardenRotating = false;
        zoomedPart = 0;
        Part1Selected.SetActive(false);
        Part2Selected.SetActive(false);
        Part3Selected.SetActive(false);
        Part4Selected.SetActive(false);

        Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
        foreach ( Renderer r in renderers )
        {
            /*if(r.tag == "SelectedPartOfGarden")
            {
                Debug.Log("ResetAll r.tag == SelectedPartOfGarden");
                Material mat = r.material;
                Color oldColor = mat.color;
                Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, 1);
                r.material.SetColor("_Color", newColor);
                r.gameObject.SetActive(false);
            }
            else */if(r.tag == "BasicGarden")
            {
                Debug.Log("ResetAll r.tag == BasicGarden");
                r.transform.rotation = Quaternion.identity;
            }
            else if(r.tag == "BasicGardenPart")
            {
                Debug.Log("ResetAll r.tag == BasicGardenPart");
                Material mat = r.material;
                Color oldColor = mat.color;
                Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, 1);
                r.material.SetColor("_Color", newColor);
            } 
        }
    }

    public void StartRotateGarden()
    {
        Debug.Log("entered startrotategarden!");
        isGardenRotating = true;
    }

    public void StopRotateGarden()
    {
        Debug.Log("entered stoptrotategarden!");
        isGardenRotating = false;
    }

    public void ToggleGarden()
    {
        ToggleVisibility();
    }

    void ToggleVisibility()
    {
        foreach ( Transform child in transform )
        {
            child.gameObject.SetActive(!child.gameObject.activeSelf);
        }
    }

    public void SetTransparency(float alpha)
    {
        if(alpha == 1)
        {
            TransparentGarden.SetActive(false);
            BasicGarden.SetActive(true);
        }
        else
        {
            TransparentGarden.SetActive(true);
            BasicGarden.SetActive(false);
        }
        //Debug.Log("Garden - SetTransparency() started!");
        //Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
        //foreach ( Renderer r in renderers )
        //{
        //   //if ( r.tag == "BasicGardenPart" || r.tag == "SelectedPartOfgarden" || r.tag == "BasicGarden")
        //   if(r.tag != "Watering")
        //   {
        //        Debug.Log("Garden - SetTransparency() if" + r.tag);
        //        //r.material.color.a = alpha;
        //        Material mat = r.material;
        //        Color oldColor = mat.color;
        //        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alpha);
        //        r.material.SetColor("_Color", newColor);

        //    }
        //}
    }

    void TurnOffVisibility()
    {
        foreach ( Transform child in transform )
        {
            child.gameObject.SetActive(false);
        }
    }

    public void StopVoice()
    {
        if ( textToSpeech.IsSpeaking() )
        {
            textToSpeech.StopSpeaking();
        }
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if(isGardenPlaced)
        {
            Debug.Log("garden on input click");
            GameObject clickedGameObject = GazeManager.Instance.HitObject;
            Debug.Log("name of clicked: " + clickedGameObject.name + "\nzoomedPart = " + zoomedPart);

            if ( clickedGameObject.name.Contains("Selected") )
            {
                zoomedPart = 0;
                clickedGameObject.SetActive(false);
            }
            else if ( ( clickedGameObject.name.Contains("Basic") ) && ( zoomedPart == 0 ) )
            {

                if ( clickedGameObject.name == ( "Part1 Basic" ) )
                {
                    zoomedPart = 1;
                    Part1Selected.SetActive(true);

                }
                else if ( clickedGameObject.name.Contains("Part2 Basic") )
                {
                    zoomedPart = 2;
                    Part2Selected.SetActive(true);
                }
                else if ( clickedGameObject.name.Contains("Part3 Basic") )
                {
                    zoomedPart = 3;
                    Part3Selected.SetActive(true);
                }
                else if ( clickedGameObject.name.Contains("Part4 Basic") )
                {
                    zoomedPart = 4;
                    Part4Selected.SetActive(true);
                }

            }
        }
        else
        {
            isGardenPlaced = true;
        }
        
    }
}
