using System;
using TMPro;
using UnityEngine;


public class Health : MonoBehaviour
{
    public int health { get; private set; } = 4;
    public TextMeshProUGUI healthText;  // Asigna el objeto Text en el Inspector

    void Start()
    {
        RefreshHealthText();
    }

    public void Damage(int damage)
    {
        health -= damage;
        RefreshHealthText();
    }

    public void GetHealthpac()
    {
        health++;
        if (health > 4)  // Asegúrate de que la vida no exceda el valor máximo
        {
            health = 4;
        }
        RefreshHealthText();
    }

    void RefreshHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + health.ToString();
        }
    }
}
