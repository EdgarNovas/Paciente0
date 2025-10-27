using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGun : MonoBehaviour
{
    public int gunUsing = 0;
    public List<GameObject> guns = new List<GameObject>();
    private float lastChangeTime;

    float lastGunChange;
    public float changeCooldown;

    SoundManager soundManager;

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= lastChangeTime + changeCooldown)
        {
            ComprobarRuedaRaton();
        }
    }

    void CambiarArmaActual()
    {
        soundManager.seleccionAudio(9, 0.5f);
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
            lastGunChange = Time.time;
            SeleccionarArmaAnterior();
        }
        else if (ruedaRaton < 0f)
        {
            lastGunChange = Time.time;
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
