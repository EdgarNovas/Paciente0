using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{

    private string currentWeapon; // Nombre del arma actual
    private Dictionary<string, Weapon> weapons; // Diccionario de armas disponibles

    void Start()
    {
        // Inicializar el diccionario de armas (dictionari es como puntero pero mas controlado por el programa)
        weapons = new Dictionary<string, Weapon>();

        // Agregar las armas disponibles al diccionario
        weapons.Add("pistola", new Weapon("Pistola"));
        weapons.Add("escopeta", new Weapon("Escopeta"));

        // Establecer el arma inicial
        currentWeapon = "pistola";
    }

    // Método para cambiar el arma actual
    public void ChangeWeapon(string newWeapon)
    {
        if (weapons.ContainsKey(newWeapon))
        {
            currentWeapon = newWeapon;
        }
        else
        {
            Debug.Log("¡Arma no encontrada!");
        }
    }

    // Método para obtener el nombre del arma actual
    public string GetCurrentWeaponName()
    {
        return weapons[currentWeapon].GetName();
    }
}

// Clase para representar un arma
public class Weapon
{
    private string name; // Nombre del arma

    public Weapon(string weaponName)
    {
        name = weaponName;
    }

    public string GetName()
    {
        return name;
    }
}
