using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public TextMeshProUGUI healthText;  // Asigna el objeto Text en el Inspector

    void Start()
    {
        RefreshHealthText();
    }
    void Update()
    {
        RefreshHealthText();
    }

    void RefreshHealthText()
    {
        if (healthText != null)
        {
            healthText.text =  GameManager.Instance.life.ToString(); 

            
        }
    }
}
