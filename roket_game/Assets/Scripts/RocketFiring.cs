using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFiring : MonoBehaviour
{
    public AudioClip AudioClip;
    public AudioSource AudioSource;
    public GameObject BulletPrefab; // Prefab, sahnedeki bir nesne de�il!
    public float speedShoat = 10f;
    public Transform shoatPosition;

    private void Update()
    {
        atesleme1();
    }

    public void atesleme1()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (BulletPrefab == null)
            {
                Debug.LogError("BulletPrefab eksik! L�tfen Inspector'dan atay�n.");
                return;
            }

            // Yeni bir mermi olu�tur
           GameObject bullet = Instantiate(BulletPrefab, shoatPosition.position, shoatPosition.rotation);
            AudioSource.PlayOneShot(AudioClip);

            // Rigidbody2D bile�enini al ve y�n belirle
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = shoatPosition.up * speedShoat;
            }

            // Mermiyi 3 saniye sonra sahneden sil
            Destroy(bullet, 3f);
        }
    }
}
