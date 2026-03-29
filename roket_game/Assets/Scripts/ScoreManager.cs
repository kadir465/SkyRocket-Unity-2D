using System.Xml.Schema;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI textPara;
    public int paraSay;
   

    private void Start()
    {
        UpdateParaUI(); // Oyunun ba��nda UI g�ncelle
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AsteroitCarp"))
        {
            paraSay += 1; // Para art�r
            UpdateParaUI(); // UI'yi g�ncelle
            
        }
    }

    private void UpdateParaUI()
    {
        textPara.text = paraSay.ToString(); // Para de�erini ekrana yaz
    }
}
