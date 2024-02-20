using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeP : MonoBehaviour
{

    public int life { get; private set; } = 4;


    public void Damage(int damage)
    {
        life -= damage;
    }

    public void GetHealthpac()
    {
        life++;

        if (life == 4)
        {
            life = 4;
        }
    }
}
