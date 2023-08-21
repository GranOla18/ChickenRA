using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarcadorLink : MonoBehaviour
{
    [SerializeField] private AudioClip openURLSFX;
    public void OpenMarkerLink(string url)
    {
        //AudioManager.instance.PlaySFX(openURLSFX);
        Application.OpenURL(url);
    }
}
