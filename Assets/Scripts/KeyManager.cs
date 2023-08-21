using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private AudioClip keySFX;

    private void OnTriggerEnter(Collider other)
    {
        AudioManager.instance.PlaySFX(keySFX);

        enemyPrefab.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
