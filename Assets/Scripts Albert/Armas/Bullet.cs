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

    void OnCollisionEnter2D(Collision2D collision)
    {
        //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);
        if (collision.transform.CompareTag("Armas") || collision.transform.CompareTag("Bullet")) return;
        Destroy(gameObject);
    }
}
