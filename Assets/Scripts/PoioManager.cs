using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoioManager : MonoBehaviour
{
    public static PoioManager instance;

    [SerializeField] private AudioClip poioDamageSFX;

    #region Singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        //enemyPrefab.SetActive(true);
        if (other.GetComponent<EnemyManager>())
        {
            AudioManager.instance.PlaySFX(poioDamageSFX);
            EventManager.GameOverEvent();
        }
    }

    //public void Damage()
    //{
    //    //GameManager.instance.GameOver();
    //    EventManager.GameOverEvent();
    //}


}
