using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDWeapon : MonoBehaviour
{
    public Sprite pistolaSprite;
    public Sprite escopetaSprite;
    public ChangeGun playerGun;
    public Sprite ComprobarArma()
    {
        if (playerGun.gunUsing == 0)
        {
            return pistolaSprite; // Asigna el sprite de la pistola
        }
        else
        {
            return escopetaSprite; // Asigna el sprite de la escopeta
        }
    }
}
