using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectWeapon : MonoBehaviour
{
    public Text weaponText; // Referencia al elemento de texto que mostrar� el arma actual

    private WeaponController weaponController; // Referencia al controlador de armas

    void Start()
    {
        // Obtener referencia al controlador de armas (puede variar dependiendo de tu implementaci�n)
        weaponController = FindObjectOfType<WeaponController>();
    }

    void Update()
    {
        // Actualizar el texto del arma actual en el HUD
        weaponText.text = "Arma actual: " + weaponController.GetCurrentWeaponName();
    }
}
