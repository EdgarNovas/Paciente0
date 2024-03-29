using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDWeapon : MonoBehaviour
{
    public Sprite pistolaSprite;
    public Sprite escopetaSprite;

    public static HUDWeapon Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null) { return; }

        Instance = this;
    }

    public void ComprobarArma(ChangeGun changeGun)
    {
        if (changeGun.gunUsing == 0)
        {
            GetComponent<SpriteRenderer>().sprite = pistolaSprite; // Asigna el sprite de la pistola
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = escopetaSprite; // Asigna el sprite de la escopeta
        }
    }

    internal void ComprobarArma()
    {
        throw new NotImplementedException();
    }
}
