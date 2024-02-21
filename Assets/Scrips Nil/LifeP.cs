using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeP : MonoBehaviour
{

    public int life { get; private set; } = 4;      


    public void Damage(int damage)
    {
        life -= damage;             // funcion quando recive daño
    }

    public void GetHealthpac()
    {
        life++;

        if (life == 4)                 // funcion quando agaras un botiquin
        {
            life = 4;
        }
    }
}
