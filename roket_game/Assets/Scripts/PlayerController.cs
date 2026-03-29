using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int speed=12;


    public Animator animator3;
    Rigidbody2D rb;
    Vector3 velocity;
    public Transform[] roads;

    
   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator3 = rb.GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // Sa�a/Sola
        float moveY = Input.GetAxis("Vertical");   // Yukar�/A�a��
        // Hareket y�n� belirleme
        velocity = new Vector3(moveX, moveY, 0f);

        // Karakterin pozisyonunu g�ncelle
        transform.position += velocity * speed * Time.deltaTime;

        // Karakterin d�n���n� ayarla
        if (moveY > 0) // Sa�a hareket
        {
            transform.rotation = Quaternion.Euler(0, 0, +90); // Sa�a d�n,

        }
        else if (moveY < 0) // Sola hareket
        {
            transform.rotation = Quaternion.Euler(0, 0, -90); // Sola d�n
        }
        else if (moveX < 0) // Yukar� hareket
        {
            transform.rotation = Quaternion.Euler(0, 0, 180); // Yukar� d�n
        }
        else if (moveX > 0) // A�a�� hareket
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); // A�a�� d�n
        }

    
    }

    public GameObject roadPrefab; // Yol prefab�
    public Transform lastRoad;    // Mevcut son yol (pozisyonunu referans al�r)
    public float roadLength = 10f; // Yol uzunlu�u (bir sonraki yolun nerede spawnlanaca��n� belirlemek i�in)
    public float roadHeight = 10f;
    public GameObject yokedilcek;
    void OnTriggerEnter2D(Collider2D collision)
    {
        // E�er �arp��an obje "Sahne" tag'ine sahipse
        if (collision.gameObject.CompareTag("Sahne"))
        {
            // Yeni yolun pozisyonunu yukar� ta��mak i�in y eksenini art�r
            Vector3 newRoadPosition = lastRoad.position + new Vector3(0f, roadHeight, 0f);

            // Yeni bir yol olu�tur
            GameObject newRoad = Instantiate(roadPrefab, newRoadPosition, Quaternion.identity);

            // Yeni yolu son yol olarak ayarla
            lastRoad = newRoad.transform;
        }

        if (collision.gameObject.CompareTag("gameSon"))
        {
        SceneManager.LoadScene("oyunSonu");
}
    }
}
