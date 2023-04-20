using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ARController : MonoBehaviour
{

    GameObject TrackedObject;
    
    // Start is called before the first frame update
    private float CurrentStep = 1;
    bool GotComponents = false;


    // the breadborad componats
    GameObject scaleBaseObject;
    GameObject breadBoard;
    GameObject LED;
    GameObject LEDLight;
    GameObject Resistor;
    GameObject Button;
    GameObject Wire1;
    GameObject Wire2;
    GameObject Wire3;


    // the ui componants
    [SerializeField] TextMeshProUGUI PlayButtonText;
    [SerializeField] GameObject ARStartScreen;
    [SerializeField] GameObject TextArea;
    [SerializeField] TextMeshProUGUI Titletext;
    [SerializeField] TextMeshProUGUI InfoText;
    [SerializeField] GameObject ScaleArea;
    [SerializeField] Slider scaleSlider;
    private void Awake()
    {
        GotComponents = false;
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
                TextArea.SetActive(true);
                ScaleArea.SetActive(true);
                GetComponants();
            }
            ContolARComponants();
            ControlInfoText();
            ScaleControl();
        }        
    }

    void GetComponants()
    {
        GotComponents = true;
        breadBoard = TrackedObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        scaleBaseObject = TrackedObject.transform.GetChild(0).gameObject;
        LED = TrackedObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
        LEDLight = LED.transform.GetChild(0).gameObject;
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
            LEDLight.SetActive(false);
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
            LEDLight.SetActive(false);
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
            LEDLight.SetActive(false);
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
            LEDLight.SetActive(false);
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
            LEDLight.SetActive(false);
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
            LEDLight.SetActive(false);
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
            LEDLight.SetActive(false);
            Resistor.SetActive(true);
            Button.SetActive(true);
            Wire1.SetActive(true);
            Wire2.SetActive(true);
            Wire3.SetActive(true);
        }
        else if (CurrentStep == 8)
        {
            breadBoard.SetActive(true);
            LED.SetActive(true);
            LEDLight.SetActive(true);
            Resistor.SetActive(true);
            Button.SetActive(true);
            Wire1.SetActive(true);
            Wire2.SetActive(true);
            Wire3.SetActive(true);
        }
    }

    void ControlInfoText()
    {
        if (CurrentStep == 1)
        {
            Titletext.text = "Step 1";
            InfoText.text = "Move your phone slightly away from the breadboard so that you are able to see the virtual one. Then click Next Step.";
        }
        else if (CurrentStep == 2)
        {
            Titletext.text = "Step 2";
            InfoText.text = "Place the LED into the breadborad. Pay attention to the orrientation. You want the longer prong which is the anode to be on the right and the shorter prong the cathode to be on the left.";
        }
        else if (CurrentStep == 3)
        {
            Titletext.text = "Step 3";
            InfoText.text = "Next is to add the resistor, we want one of the prongs to be lined up with the cathode of the LED.";
        }
        else if (CurrentStep == 4)
        {
            Titletext.text = "Step 4";
            InfoText.text = "Add in the button to bread board by placing it over the middle part of the breadboard.";
        }
        else if (CurrentStep == 5)
        {
            Titletext.text = "Step 5";
            InfoText.text = "This wire is used to connect up the button to the LED.";
        }
        else if (CurrentStep == 6)
        {
            Titletext.text = "Step 6";
            InfoText.text = "This wire is used to connect the resistor to the ground/neggative side of the breadboard.";
        }
        else if (CurrentStep == 7)
        {
            Titletext.text = "Step 7";
            InfoText.text = "This wire connects the button to the possitive side of the breadboard completing the circuit.";
        }
        else if (CurrentStep == 8)
        {
            Titletext.text = "Step 8";
            InfoText.text = "The circuit should now be completed, make sure the breadboard is powered and press the button to turn on the LED. If it did not work, go back through the steps to try and work out what went wrong.";
        }
    }

    void ScaleControl()
    {
        scaleBaseObject.transform.localScale = new Vector3(scaleSlider.value, scaleSlider.value,scaleSlider.value);
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
        else if (CurrentStep == 8)
        {
            
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
        }
        
        else if (CurrentStep == 8)
        {
            
        }


        PlayButtonText.text = "Play Step";
        if (CurrentStep <= 7)
        {
            CurrentStep++;
        }
        

    }
    public void PreviousStep()
    {
        PlayButtonText.text = "Play Step";
        if (CurrentStep >= 2)
        {
            CurrentStep--;
        }
        


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
        }
        else if (CurrentStep == 8)
        {            
            
        }
    }
}
