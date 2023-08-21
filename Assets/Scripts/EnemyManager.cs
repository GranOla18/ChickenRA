using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour, IDamage
{
    [SerializeField] private int health;
    [SerializeField] private float step;

    [SerializeField] private AudioClip enemyDamageSFX;


    //public navmeshsur
    private void OnEnable()
    {
        health = 3;
    }

    public void Damage()
    {
        AudioManager.instance.PlaySFX(enemyDamageSFX);
        health -= 1;

        if (health <= 0)
        {
            this.gameObject.SetActive(false);
            GameManager.instance.Win();
        }
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, PoioManager.instance.transform.position, step * Time.deltaTime);
    
    }
}
