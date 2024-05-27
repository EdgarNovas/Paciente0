using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletDuration = 2;

    //---> Codigo para si mas adelante queremos añadir efecto de explosion a la bullet
    //public GameObject hitEffect;
    private void Start()
    { 
        Destroy(gameObject, bulletDuration);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);

        if (!collider.isTrigger && !collider.CompareTag("Water") && !collider.CompareTag("Player"))
            Destroy(gameObject);
    }
}
