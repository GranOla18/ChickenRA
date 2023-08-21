using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class PrefabController : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Vector3 offset;

    private GameObject prefabInstance;
    private ARTrackedImageManager aRTrackedImageManager;

    //public Text text;

    private void OnEnable()
    {
        aRTrackedImageManager = gameObject.GetComponent<ARTrackedImageManager>();

        aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnDisable()
    {
        aRTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (ARTrackedImage trackedImage in args.added)
        {
            //text.text = "Instancia";
            prefabInstance = Instantiate(prefab, trackedImage.transform);
            EventManager.FoundTrackedImage();
        }

        foreach (ARTrackedImage trackedImage in args.updated)
        {
            //text.text = "Update";

            if(trackedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking)
            {
                //text.text = "Tracking";

                if (prefabInstance)
                {
                    prefabInstance.SetActive(true);
                    EventManager.FoundTrackedImage();
                }
                else
                {
                    //text.text = "Instancia update";

                    prefabInstance = Instantiate(prefab, trackedImage.transform);
                    EventManager.FoundTrackedImage();
                }
                
            }
            else if(trackedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Limited)
            {
                //text.text = "Limited";
                prefabInstance.SetActive(false);
                EventManager.LostTrackedImage();
            }

        }

        foreach (ARTrackedImage trackedImage in args.removed)
        {
            //text.text = "Bye";
            prefabInstance.SetActive(false);
            EventManager.LostTrackedImage();
        }
    }

    public void RestartPrefab()
    {
        if (prefabInstance)
        {
            Destroy(prefabInstance);
        }
    }
}
