using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ShopManager : MonoBehaviour
{
   public GameObject Mavi�sBig;
    public GameObject Mavi�sSmall;
    public GameObject Siyah�s;

    private static Buy instance;

    private void Awake()
    {
OnButtonPress();
       
    }

    public void ActivateSiyah�s()
    {
        if (Siyah�s != null)
        {
            Siyah�s.SetActive(true);
        }
    }

    public void OnButtonPress()
    {
        SceneManager.LoadScene("SampleScene");
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Nesneyi sahneler aras�nda korur
        }
        else
        {
            Destroy(gameObject); // Zaten varsa, birden fazla olu�turulmas�n� engeller
        }

        // Siyah�s'� aktif hale getir
        ActivateSiyah�s();
    }
}


