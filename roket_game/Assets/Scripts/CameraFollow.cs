using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target; // Kamera takip hedefi
    public float cameraSpeed; // Kamera h�z� (0 ile 1 aras�nda bir de�er)

        void Update()
        {// slerp daha yumu�ak bir ge�i� olssun diye destek verir
        if(gameObject!=null)
        {
            transform.position = Vector3.Slerp(transform.position, new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z), cameraSpeed);

        }

    }

}

