using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FindTrackedObject : MonoBehaviour
{

    GameObject TrackedObject;
    [SerializeField] TextMeshProUGUI text;
    // Start is called before the first frame update
    private float CurrentStep = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(TrackedObject == null)
        {
            TrackedObject = GameObject.FindGameObjectWithTag("TrackedItem");
        }
        else
        {
            text.text = "somthing";
        }
    }

    public void changeToCube()
    {
        if (!(TrackedObject==null))
        {

        }
    }
    public void changeToSphere()
    {
        text.text = "sphere";
        if (!(TrackedObject == null))
        {
            TrackedObject.transform.GetChild(0).gameObject.SetActive(true);
            TrackedObject.transform.GetChild(1).gameObject.SetActive(false);
            TrackedObject.transform.GetChild(2).gameObject.SetActive(true);

        }
    }

    public void changeToNull()
    {
        text.text = "nothibg";
        if (!(TrackedObject == null))
        {
            TrackedObject.transform.GetChild(0).gameObject.SetActive(false);
            TrackedObject.transform.GetChild(1).gameObject.SetActive(false);
            TrackedObject.transform.GetChild(2).gameObject.SetActive(false);

        }
    }
}
