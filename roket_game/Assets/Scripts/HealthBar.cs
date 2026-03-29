using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image[] healthImages; // Kalpler bir dizi olarak tan�mland�
    public float maxHealth = 100f;
    private float currentHealth;
    public GameObject destroy;

    public Scenes sahne;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("mermi")) // E�er �arpma nesnesine temas ederse
        {
            currentHealth =currentHealth-5; // Sa�l��� azalt
            UpdateHealthBar(); // Sa�l�k bar�n� g�ncelle
        }
    }

    void UpdateHealthBar()
    {
        // Sa�l�k de�erine g�re g�rselleri yok et
        int healthIndex = Mathf.FloorToInt((currentHealth / maxHealth) * healthImages.Length);

        for (int i = 0; i < healthImages.Length; i++)
        {
            healthImages[i].gameObject.SetActive(i < healthIndex); // Sa�l�k durumuna g�re aktif/pasif yap
        }

        if (currentHealth <= 0)
        {
            GameOver(); // Sa�l�k s�f�rland���nda oyun biti� i�lemi
        }
    }

    void GameOver()
    {
       Destroy(gameObject);
       if(gameObject!=null)
            SceneManager.LoadScene("oyunSonu");
    }
}
