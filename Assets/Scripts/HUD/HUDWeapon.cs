using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDWeapon : MonoBehaviour
{
    public Sprite weaponSelectSprite;
    public Sprite defaultSprite;
    public ChangeGun playerGun;
    public int numWeapon;
    public Sprite CheckWeapon()
    {
        if (playerGun.gunUsing == 0 && numWeapon == 0)
        {
            return weaponSelectSprite; // Asigna el sprite de la pistola
        }
        if (playerGun.gunUsing == 1 && numWeapon == 1)
        {
            return weaponSelectSprite; // Asigna el sprite de la escopeta
        }
        return defaultSprite;

    }
}