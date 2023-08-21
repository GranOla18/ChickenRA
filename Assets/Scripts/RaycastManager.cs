using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager : MonoBehaviour
{
    public GameObject prefab;
    Ray rayo;
    RaycastHit choque;
    private Touch touch;
    private GameObject prefabInstance;

    public Camera ar_camera;

    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase.Equals(TouchPhase.Began))
            {
                //Genera rayo desde la camara hacia el frente
                rayo = ar_camera.ScreenPointToRay(touch.position);

                if (Physics.Raycast(rayo, out choque))
                {
                    if (!prefabInstance)
                    {
                        prefabInstance = Instantiate(prefab, choque.point, Quaternion.identity);
                        prefabInstance.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                    }
                }
            }

        }
    }

    public void StopPlaneDetection()
    {
        if (prefabInstance)
        {
            Destroy(prefabInstance);
        }
    }
}
