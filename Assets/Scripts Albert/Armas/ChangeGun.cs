using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGun : MonoBehaviour
{
    public int gunUsing = 0;
    public List<GameObject> guns = new List<GameObject>();
    public float changeInterval = 2;
    private float lastChangeTime;

    


    // Update is called once per frame
    void Update()
    {
        if (Time.time >= lastChangeTime + changeInterval)
        {
            ComprobarRuedaRaton();
        }
    }

    void CambiarArmaActual()
    {
        
            for (int i = 0; i < guns.Count; i++)
            {
                guns[i].SetActive(false);
            }
            guns[gunUsing].SetActive(true);
            lastChangeTime = Time.time; 
        
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
        if (gunUsing >= (guns.Count - 1))
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
