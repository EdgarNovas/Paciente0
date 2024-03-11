using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGun : MonoBehaviour
{
    int gunUsing = 0;
    public List<GameObject> guns = new List<GameObject>();

    /*void Start()
    {
        
    }*/
    // Update is called once per frame
    void Update()
    {
        ComprobarRuedaRaton();
    }

    void CambiarArmaActual()
    {
        for(int i = 0; i < guns.Count; i++)
        {
            guns[i].SetActive(false);
        }
        guns[gunUsing].SetActive(true);
    }

    void ComprobarRuedaRaton()
    {
        float ruedaRaton = Input.GetAxis("Mouse ScrollWheel");
        if (ruedaRaton > 0f)
        {
            SeleccionarArmaAnterior();
        }
        else if (ruedaRaton < 0f)
        {
            SeleccionarArmaSiguiente();
        }
    }


    void SeleccionarArmaAnterior()
    {
        if (gunUsing == 0)
        {
            gunUsing = guns.Count - 1;
        }
        else
        {
            gunUsing--; //se resta
        }
        CambiarArmaActual();
    }

    void SeleccionarArmaSiguiente()
    {
        if (gunUsing >= (guns.Count-1))
        {
            gunUsing = 0;
        }
        else
        { 
            gunUsing++; //se suma
        }
        CambiarArmaActual();
    }
}
