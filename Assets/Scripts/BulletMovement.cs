using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float step;
    private Vector3 targetPos;
    private float bulletLife;

    private void OnEnable()
    {
        targetPos = transform.position + transform.forward * 20;
        bulletLife = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyManager>())
        {
            this.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step * Time.deltaTime);

        bulletLife += Time.deltaTime;

        if (bulletLife >= 6)
        {
            this.gameObject.SetActive(false);
        }
    }
}
