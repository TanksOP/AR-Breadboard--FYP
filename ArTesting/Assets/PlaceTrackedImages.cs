using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class PlaceTrackedImages : MonoBehaviour
{
    // refrence to AR tracked image manager
    private ARTrackedImageManager _trackedImageManager;

    // list of prefabs to instantiate
    public GameObject[] ArPrefabs;

    // dictionary of created Prefabs
    private readonly Dictionary<string, GameObject> _instantiatedPrefabs = new Dictionary<string, GameObject>();

    private void Awake()
    {
        _trackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        //attach event handler when tracked images change
        _trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }
    private void OnDisable()
    {
        //attach event handler when tracked images change
        _trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    //event handler
    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        // loop through all new tracked images that have been detected
        foreach(var trackedImage in eventArgs.added)
        {
            // get the name of the refrence image
            var imageName = trackedImage.referenceImage.name;
            // now loop over the array of prefabs
            foreach(var curPrefab in ArPrefabs)
            {
                //check whether this prefab matches the tracked image name, and that
                //the prefab hasn't already been created
                if(string.Compare(curPrefab.name, imageName, System.StringComparison.OrdinalIgnoreCase) == 0 && !_instantiatedPrefabs.ContainsKey(imageName))
                {
                    // instantiat the prefab, and parent to ARTrackedImage
                    var newPrefab = Instantiate(curPrefab, trackedImage.transform);
                    // add prefab to the array
                    _instantiatedPrefabs[imageName] = newPrefab;
                }
            }
        }
        // for prefabs that have been created set them active or not depending if image is currerly beign tracked
        foreach (var trackedImage in eventArgs.updated)
        {
            _instantiatedPrefabs[trackedImage.referenceImage.name].SetActive(trackedImage.trackingState == TrackingState.Tracking);
        }

        // if the AR subsystem has given up lookign for the tracked image
        foreach(var trackedImage in eventArgs.removed)
        {
            //destroy prefab
            Destroy(_instantiatedPrefabs[trackedImage.referenceImage.name]);
            // remove from array
            _instantiatedPrefabs.Remove(trackedImage.referenceImage.name);
        }
    }
}
