using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGun : MonoBehaviour
{
    public int gunUsing = 0;
    public List<GameObject> guns = new List<GameObject>();

    float lastGunChange;
    public float changeCooldown;

    public SoundManager soundManager;

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ComprobarRuedaRaton();
    }

    void CambiarArmaActual()
    {
        soundManager.seleccionAudio(9, 0.5f);
        for (int i = 0; i < guns.Count; i++)
        {
            guns[i].SetActive(false);
        }
        guns[gunUsing].SetActive(true);
    }

    void ComprobarRuedaRaton()
    {
        if (Time.time - lastGunChange > changeCooldown)
        {
            float ruedaRaton = Input.GetAxis("Mouse ScrollWheel");
            if (ruedaRaton > 0f)
            {
                lastGunChange = Time.time;
                SeleccionarArmaAnterior();
            }
            else if (ruedaRaton < 0f)
            {
                lastGunChange = Time.time;
                SeleccionarArmaSiguiente();
            }
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
