using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action GameOver;
    public static event Action ShowARMenu;
    public static event Action HideARMenu;
    public static event Action Restart;
    public static event Action StopPlaneDetection;

    public static void GameOverEvent()
    {
        GameOver?.Invoke();
    }

    public static void RestartEvent()
    {
        Restart?.Invoke();
    }

    public static void LostTrackedImage()
    {
        ShowARMenu?.Invoke();
    }

    public static void FoundTrackedImage()
    {
        HideARMenu?.Invoke();
    }

    public static void StopPlaneEvent()
    {
        StopPlaneDetection?.Invoke();
    }
}
