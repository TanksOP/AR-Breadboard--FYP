using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ArObjectsController : MonoBehaviour
{
    private GameObject spawnedGameObject;
    ARTrackedImageManager ARTrackedImageManager;

    [SerializeField] GameObject cube;
    [SerializeField] GameObject sphere;

   

    private void Awake()
    {
        
        ARTrackedImageManager.trackedImagePrefab = sphere;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeToCube()
    {
        ARTrackedImageManager.trackedImagePrefab = cube;
        
    }
    public void changeToSphere()
    {
        ARTrackedImageManager.trackedImagePrefab = sphere;
    }

    public void changeToNull()
    {
        ARTrackedImageManager.trackedImagePrefab = null;
    }
}
