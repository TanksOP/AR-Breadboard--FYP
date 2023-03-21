using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ARController : MonoBehaviour
{

    GameObject TrackedObject;
    [SerializeField] TextMeshProUGUI PlayButtonText;
    // Start is called before the first frame update
    private float CurrentStep = 1;
    bool GotComponents = false;

    

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
        else if (CurrentStep == 3)
        {
            breadBoard.SetActive(true);
            LED.SetActive(true);
            Resistor.SetActive(true);
            Button.SetActive(false);
        }
        else if (CurrentStep == 4)
        {
            breadBoard.SetActive(true);
            LED.SetActive(true);
            Resistor.SetActive(true);
            Button.SetActive(true);
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
            // LED Animations
            if (!LED.GetComponent<Animator>().GetBool("Played"))
            {
                LED.GetComponent<Animator>().SetTrigger("Play");
                LED.GetComponent<Animator>().SetBool("Played", true);
                PlayButtonText.text = "Replay Step";
            }
            else
            {
                LED.GetComponent<Animator>().SetTrigger("Replay");
                LED.GetComponent<Animator>().SetTrigger("Play");
            } 
        }


        else if (CurrentStep == 3)
        {
            // Resistor Animations
            if (!Resistor.GetComponent<Animator>().GetBool("Played"))
            {
                Resistor.GetComponent<Animator>().SetTrigger("Play");
                Resistor.GetComponent<Animator>().SetBool("Played", true);
                PlayButtonText.text = "Replay Step";
            }
            else
            {
                Resistor.GetComponent<Animator>().SetTrigger("Replay");
                Resistor.GetComponent<Animator>().SetTrigger("Play");
            }
        }
        else if (CurrentStep == 4)
        {
            // Resistor Animations
            if (!Button.GetComponent<Animator>().GetBool("Played"))
            {
                Button.GetComponent<Animator>().SetTrigger("Play");
                Button.GetComponent<Animator>().SetBool("Played", true);
                PlayButtonText.text = "Replay Step";
            }
            else
            {
                Button.GetComponent<Animator>().SetTrigger("Replay");
                Button.GetComponent<Animator>().SetTrigger("Play");
            }
        }
    }

    public void nextStep()
    {
        
        if (CurrentStep == 2)
        {
            // if the animation of the last step not played 
            if (!LED.GetComponent<Animator>().GetBool("Played"))
            {
                LED.GetComponent<Animator>().SetTrigger("Skipped");
                LED.GetComponent<Animator>().SetBool("Played", true);
            }
        }

        else if (CurrentStep == 3)
        {
            // if the animation of the last step not played 
            if (!Resistor.GetComponent<Animator>().GetBool("Played"))
            {
                Resistor.GetComponent<Animator>().SetTrigger("Skipped");
                Resistor.GetComponent<Animator>().SetBool("Played", true);
            }
        }

        else if (CurrentStep == 4)
        {
            // if the animation of the last step not played 
            if (!Button.GetComponent<Animator>().GetBool("Played"))
            {
                Button.GetComponent<Animator>().SetTrigger("Skipped");
                Button.GetComponent<Animator>().SetBool("Played", true);
            }
        }

        PlayButtonText.text = "Play Step";
        CurrentStep++;

    }
    public void PreviousStep()
    {
        PlayButtonText.text = "Play Step";
        CurrentStep--;


        if (CurrentStep == 2)
        {
            LED.GetComponent<Animator>().SetTrigger("Replay");
            LED.GetComponent<Animator>().SetBool("Played", false);
        }

        else if (CurrentStep == 3)
        {
            Resistor.GetComponent<Animator>().SetTrigger("Replay");
            Resistor.GetComponent<Animator>().SetBool("Played", false);
        }
        else if (CurrentStep == 4)
        {
            Button.GetComponent<Animator>().SetTrigger("Replay");
            Button.GetComponent<Animator>().SetBool("Played", false);
        }



    }
}
