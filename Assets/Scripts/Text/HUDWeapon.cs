using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDWeapon : MonoBehaviour
{
    public SpriteRenderer weaponSpriteRenderer; // Referencia al SpriteRenderer para mostrar el sprite del arma
    private ChangeGun changeGun; // Referencia al controlador de armas

    void Start()
    {
        // Obtener referencia al controlador de armas (puede variar dependiendo de tu implementación)
        changeGun = FindObjectOfType<ChangeGun>();

        // Asegúrate de que weaponSpriteRenderer no sea nulo
        if (weaponSpriteRenderer == null)
        {
            Debug.LogError("No se ha asignado un SpriteRenderer para mostrar el sprite del arma en el HUD.");
        }
    }

    void Update()
    {
        // Obtener el sprite del arma actual desde el controlador de armas
        Sprite currentWeaponSprite = changeGun.GetCurrentWeaponSprite();

        // Asegurarse de que el sprite no sea nulo y que el SpriteRenderer esté asignado
        if (currentWeaponSprite != null && weaponSpriteRenderer != null)
        {
            // Mostrar el sprite del arma en el HUD
            weaponSpriteRenderer.sprite = currentWeaponSprite;
        }
    }
}
