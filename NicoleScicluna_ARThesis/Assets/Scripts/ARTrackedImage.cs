using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class ARTrackedImage : MonoBehaviour
{
    
    public GameObject shoot;
    public GameObject timer;
    public GameObject score;
    //public GameObject placementIndicator;
    
    private ARTrackedImageManager arTrackedImageManager;
   
    void Start()
    {
        arTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        shoot.SetActive(false);
        timer.SetActive(false);
        score.SetActive(false);
     
    }
    void Update()
    {
        shoot.SetActive(true);
        timer.SetActive(true);
        score.SetActive(true);
    }

    public void OnEnable()
    {
        arTrackedImageManager.trackedImagesChanged += OnImageChanged;
     
    }
    
    public void OnDisable()
    {
        arTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    public void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var trackedImage in args.added)
        {
            Debug.Log(trackedImage.name);
        }
    }

}
