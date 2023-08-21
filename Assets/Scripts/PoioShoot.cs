using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoioShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private List<GameObject> bullets;
    private PoioMovement poio;

    [SerializeField] private AudioClip shootSFX;

    private void OnEnable()
    {
        bullets = new List<GameObject>();
    }

    public void Shoot()
    {
        AudioManager.instance.PlaySFX(shootSFX);
        poio = FindObjectOfType<PoioMovement>();
        BulletPool();
    }

    private void BulletPool()
    {
        bool hayObjDesactivados = false;

        for (int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                bullets[i].transform.position = poio.transform.position + new Vector3(0, 0.05f, 0);
                bullets[i].transform.rotation = Quaternion.LookRotation(poio.transform.forward);
                bullets[i].SetActive(true);
                hayObjDesactivados = true;
                break;
            }
        }

        if (!hayObjDesactivados)
        {
            bullets.Add(Instantiate(bullet, poio.transform.position + new Vector3(0, 0.05f, 0), Quaternion.LookRotation(poio.transform.forward)));
        }
    }
}
