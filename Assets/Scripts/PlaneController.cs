using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.StopPlaneDetection += DisablePlane;
    }

    private void OnDisable()
    {
        EventManager.StopPlaneDetection -= DisablePlane;
    }

    public void DisablePlane()
    {
        this.gameObject.SetActive(false);
    }
}
