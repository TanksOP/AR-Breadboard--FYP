using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ARController : MonoBehaviour
{

    GameObject TrackedObject;
    
    // Start is called before the first frame update
    private float CurrentStep = 1;
    bool GotComponents = false;

    
    // the breadborad componats
    GameObject breadBoard;
    GameObject LED;
    GameObject Resistor;
    GameObject Button;
    GameObject Wire1;
    GameObject Wire2;
    GameObject Wire3;


    // the ui componants
    [SerializeField] TextMeshProUGUI PlayButtonText;
    [SerializeField] GameObject ARStartScreen;
    [SerializeField] GameObject AREndScreen;
    private void Awake()
    {
        GotComponents = false;
        AREndScreen.SetActive(false);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (TrackedObject == null)
        {
            ARStartScreen.SetActive(true);
            TrackedObject = GameObject.FindGameObjectWithTag("TrackedItem");
        }
        else
        {
            if (!GotComponents)
            {
                ARStartScreen.SetActive(false);
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
        Wire1 = TrackedObject.transform.GetChild(0).gameObject.transform.GetChild(4).gameObject;
        Wire2 = TrackedObject.transform.GetChild(0).gameObject.transform.GetChild(5).gameObject;
        Wire3 = TrackedObject.transform.GetChild(0).gameObject.transform.GetChild(6).gameObject;
    }

    void ContolARComponants()
    {
        
        // works out which stuff to display


        // EmptyBreadboard
        if (CurrentStep == 1)
        {
            breadBoard.SetActive(true);
            LED.SetActive(false);
            Resistor.SetActive(false);
            Button.SetActive(false);
            Wire1.SetActive(false);
            Wire2.SetActive(false);
            Wire3.SetActive(false);
        }
        // Add LED
        else if (CurrentStep == 2)
        {
            breadBoard.SetActive(true);
            LED.SetActive(true);
            Resistor.SetActive(false);
            Button.SetActive(false);
            Wire1.SetActive(false);
            Wire2.SetActive(false);
            Wire3.SetActive(false);
        }
        // Add resistor
        else if (CurrentStep == 3)
        {
            breadBoard.SetActive(true);
            LED.SetActive(true);
            Resistor.SetActive(true);
            Button.SetActive(false);
            Wire1.SetActive(false);
            Wire2.SetActive(false);
            Wire3.SetActive(false);
        }
        // Add Button
        else if (CurrentStep == 4)
        {
            breadBoard.SetActive(true);
            LED.SetActive(true);
            Resistor.SetActive(true);
            Button.SetActive(true);
            Wire1.SetActive(false);
            Wire2.SetActive(false);
            Wire3.SetActive(false);
        }
        // Add Wire1
        else if (CurrentStep == 5)
        {
            breadBoard.SetActive(true);
            LED.SetActive(true);
            Resistor.SetActive(true);
            Button.SetActive(true);
            Wire1.SetActive(true);
            Wire2.SetActive(false);
            Wire3.SetActive(false);
        }
        // Add Wire2
        else if (CurrentStep == 6)
        {
            breadBoard.SetActive(true);
            LED.SetActive(true);
            Resistor.SetActive(true);
            Button.SetActive(true);
            Wire1.SetActive(true);
            Wire2.SetActive(true);
            Wire3.SetActive(false);
        }
        // Add Wire3
        else if (CurrentStep == 7)
        {
            breadBoard.SetActive(true);
            LED.SetActive(true);
            Resistor.SetActive(true);
            Button.SetActive(true);
            Wire1.SetActive(true);
            Wire2.SetActive(true);
            Wire3.SetActive(true);
        }


    }

    public void AnimationButton()
    {
        
        if (CurrentStep == 1)
        {
            
        }
        
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
            // Button Animations
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

        else if (CurrentStep == 5)
        {
            // Wire1 Animations
            if (!Wire1.GetComponent<Animator>().GetBool("Played"))
            {
                Wire1.GetComponent<Animator>().SetTrigger("Play");
                Wire1.GetComponent<Animator>().SetBool("Played", true);
                PlayButtonText.text = "Replay Step";
            }
            else
            {
                Wire1.GetComponent<Animator>().SetTrigger("Replay");
                Wire1.GetComponent<Animator>().SetTrigger("Play");
            }
        }

        else if (CurrentStep == 6)
        {
            // Wire2 Animations
            if (!Wire2.GetComponent<Animator>().GetBool("Played"))
            {
                Wire2.GetComponent<Animator>().SetTrigger("Play");
                Wire2.GetComponent<Animator>().SetBool("Played", true);
                PlayButtonText.text = "Replay Step";
            }
            else
            {
                Wire2.GetComponent<Animator>().SetTrigger("Replay");
                Wire2.GetComponent<Animator>().SetTrigger("Play");
            }
        }

        else if (CurrentStep == 7)
        {
            // Wire1 Animations
            if (!Wire3.GetComponent<Animator>().GetBool("Played"))
            {
                Wire3.GetComponent<Animator>().SetTrigger("Play");
                Wire3.GetComponent<Animator>().SetBool("Played", true);
                PlayButtonText.text = "Replay Step";
            }
            else
            {
                Wire3.GetComponent<Animator>().SetTrigger("Replay");
                Wire3.GetComponent<Animator>().SetTrigger("Play");
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
        else if (CurrentStep == 5)
        {
            // if the animation of the last step not played 
            if (!Wire1.GetComponent<Animator>().GetBool("Played"))
            {
                Wire1.GetComponent<Animator>().SetTrigger("Skipped");
                Wire1.GetComponent<Animator>().SetBool("Played", true);
            }
        }

        else if (CurrentStep == 6)
        {
            // if the animation of the last step not played 
            if (!Wire2.GetComponent<Animator>().GetBool("Played"))
            {
                Wire2.GetComponent<Animator>().SetTrigger("Skipped");
                Wire2.GetComponent<Animator>().SetBool("Played", true);
            }
        }

        else if (CurrentStep == 7)
        {
            // if the animation of the last step not played 
            if (!Wire3.GetComponent<Animator>().GetBool("Played"))
            {
                Wire3.GetComponent<Animator>().SetTrigger("Skipped");
                Wire3.GetComponent<Animator>().SetBool("Played", true);
            }
            AREndScreen.SetActive(true);
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
        else if (CurrentStep == 5)
        {
            Wire1.GetComponent<Animator>().SetTrigger("Replay");
            Wire1.GetComponent<Animator>().SetBool("Played", false);
        }
        else if (CurrentStep == 6)
        {
            Wire2.GetComponent<Animator>().SetTrigger("Replay");
            Wire2.GetComponent<Animator>().SetBool("Played", false);
        }
        else if (CurrentStep == 7)
        {
            Wire3.GetComponent<Animator>().SetTrigger("Replay");
            Wire3.GetComponent<Animator>().SetBool("Played", false);
            AREndScreen.SetActive(false);
        }
    }
}
