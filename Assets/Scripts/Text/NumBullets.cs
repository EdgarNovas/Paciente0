using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;

public class NumBullets : MonoBehaviour
{
    public TextMeshProUGUI bulletsText;


    void Start()
    {
        RefreshBulletsText();
    }
    void Update()
    {
        RefreshBulletsText();
    }

    void RefreshBulletsText()
    {
        if (bulletsText != null)
        {
            bulletsText.text = "Bullets: " + GameManager.Instance.amountBullets.ToString();
        }
    }
}
