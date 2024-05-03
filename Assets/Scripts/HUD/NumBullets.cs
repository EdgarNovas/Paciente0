using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumBullets : MonoBehaviour
{
    public TextMeshProUGUI bulletsText;
    public ChangeGun playerGun;

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
            if (playerGun.gunUsing == 0) { 
                bulletsText.text = GameManager.Instance.amountBulletsPistola.ToString();
            }
            else
                bulletsText.text = GameManager.Instance.amountBulletsEscopeta.ToString();
        }
    }
}

