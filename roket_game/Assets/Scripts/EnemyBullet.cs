using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations; // TextMeshPro namespace

public class AsteroitSpanwner : MonoBehaviour
{
    public GameObject hedef;
    [SerializeField]
    private int speed = 0;
    public Animator animator1;
    public Animator animator2;
   
    public Animator animator3;
    Rigidbody2D rb;
    Vector3 velocity;
    public Transform[] roads;


    public GameObject BulletPrefab; // Prefab, sahnedeki bir nesne de�il!
    public float speedShoat = 7f;
    public Transform shoatPosition;
    public float fireRate = 2.5f; // Mermilerin ate�lenme s�kl��� (saniye cinsinden)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator3 = rb.GetComponent<Animator>();

        // Oto mermi ate�lemeyi ba�lat
        InvokeRepeating(nameof(atesleme1), 1f, fireRate);

    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // Sa�a/Sola
        float moveY = Input.GetAxis("Vertical");   // Yukar�/A�a��
        velocity = new Vector3(moveX, moveY, 0f);
        transform.position += velocity * speed * Time.deltaTime;

        // Karakterin d�n���n� ayarla
        // Karakterin d�n���n� ayarla
        if (moveY < 0) // Sa�a hareket
        {
            transform.rotation = Quaternion.Euler(0, 0, +90); // Sa�a d�n,

        }
        else if (moveY > 0) // Sola hareket
        {
            transform.rotation = Quaternion.Euler(0, 0, -90); // Sola d�n
        }
        else if (moveX > 0) // Yukar� hareket
        {
            transform.rotation = Quaternion.Euler(0, 0, 180); // Yukar� d�n
        }
        else if (moveX < 0) // A�a�� hareket
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); // A�a�� d�n
        }
    }

    public void atesleme1()
    {
        if (BulletPrefab == null)
        {
            Debug.LogError("BulletPrefab eksik! L�tfen Inspector'dan atay�n.");
            return;
        }

        // Yeni bir mermi olu�tur
        
        if (animator3 != null) // Transform nesnesi hala sahnede mi?
        {
            GameObject bullet = Instantiate(BulletPrefab, shoatPosition.position, shoatPosition.rotation);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = shoatPosition.up * speedShoat;
               
            }

            // Mermiyi 3 saniye sonra sahneden sil
            Destroy(bullet, 1.5f);
        }
        // Rigidbody2D bile�enini al ve y�n belirle
      

       
    }
 
}
