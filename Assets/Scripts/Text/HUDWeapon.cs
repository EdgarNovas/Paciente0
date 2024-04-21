using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDWeapon : MonoBehaviour
{
    public Sprite gunSprite;
    public Sprite shotgunSprite;
    public ChangeGun playerGun;
    public int numWeapon;
    public Sprite CheckWeapon()
    {
        if (playerGun.gunUsing == 0 && numWeapon == 0)
        {
            shotgunSprite = null;
            return gunSprite; // Asigna el sprite de la pistola
        }
        else
        {
            gunSprite = null;
            return shotgunSprite; // Asigna el sprite de la escopeta
        }

    }
}