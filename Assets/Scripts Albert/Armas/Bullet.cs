using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //---> Codigo para si mas adelante queremos añadir efecto de explosion a la bullet

    //public GameObject hitEffect;
    private void Start()
    {
        Destroy(gameObject,4);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);

        if (!collider.isTrigger && !collider.CompareTag("Water") && !collider.CompareTag("Player"))
            Destroy(gameObject);
    }
}
