using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health { get; private set; } = 4;
    public TextMeshProUGUI healthText;  // Asigna el objeto Text en el Inspector

    void Start()
    {
        RefreshHealthText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Damage(1);
            Debug.Log(health);
        }
    }

    public void Damage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
            RefreshHealthText();
        }
        else
        {
            //MORISTE
            SceneManager.LoadScene(1);
        }


    }

    public void GetHealthpac()
    {
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
