using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ARController : MonoBehaviour
{

    GameObject TrackedObject;
    //[SerializeField] TextMeshProUGUI text;
    // Start is called before the first frame update
    private float CurrentStep = 1;
    bool GotComponents = false;

    bool AnimationPlaying = false;

    GameObject breadBoard;
    GameObject LED;
    GameObject Resistor;
    GameObject Button;

    private void Awake()
    {
        GotComponents = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (TrackedObject == null)
        {
            TrackedObject = GameObject.FindGameObjectWithTag("TrackedItem");
        }
        else
        {
            if (!GotComponents)
            {
                GetComponants();
            }
            ContolARComponants();
        }
    }

    void GetComponants()
    {
        GotComponents = true;
        breadBoard = TrackedObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        LED = TrackedObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
        Resistor = TrackedObject.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject;
        Button = TrackedObject.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject;
    }

    void ContolARComponants()
    {
        
        // works out which stuff to display


        // Add LED
        if (CurrentStep == 1)
        {
            breadBoard.SetActive(true);
            LED.SetActive(false);
            Resistor.SetActive(false);
            Button.SetActive(false);
        }
        // Add Button
        else if (CurrentStep == 2)
        {
            breadBoard.SetActive(true);
            LED.SetActive(true);
            Resistor.SetActive(false);
            Button.SetActive(false);
        }
    }

    public void AnimationButton()
    {
        // Add LED
        if (CurrentStep == 1)
        {
            
        }
        // Add Button
        else if (CurrentStep == 2)
        {
            LED.GetComponent<Animation>().Play();
        }
    }

    public void nextStep()
    {
        CurrentStep++;
    }
    public void PreviousStep()
    {
        CurrentStep--;
    }
}
