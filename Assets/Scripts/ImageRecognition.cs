using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class ImageRecognition : MonoBehaviour
{
    ARTrackedImageManager _arTrackedImageManager;

    public GameObject tRexInfo;

    public Text debugText;

    private void Awake()
    {
        _arTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    public void OnEnable()
    {
        _arTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    public void OnDisable()
    {
        _arTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    public void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var trackedImage in args.added)
        {
            //debugText.text += (trackedImage.referenceImage.name + " detected") + "\n";
            if (trackedImage.referenceImage.name == "T-Rex")
            {
                //_arTrackedImageManager.trackedImagePrefab = tRexInfo;
                Instantiate(tRexInfo);
                //debugText.text += "prefab should be changed" + "\n";
            }

        }
    }
}
