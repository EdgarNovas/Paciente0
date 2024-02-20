using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    //[SerializeField] CinemachineVirtualCamera cameraCM;
    // Start is called before the first frame update
    public float cameraMoveSpeed = 5f;

    void Update()
    {
        // Obtener la posici�n del mouse en el mundo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Mantener la posici�n Z de la c�mara constante (en un juego 2D)
        mousePosition.z = transform.position.z;

        // Mover la c�mara hacia la posici�n del mouse
        transform.position = Vector3.Lerp(transform.position, mousePosition, Time.deltaTime * cameraMoveSpeed);
    }
}

    
