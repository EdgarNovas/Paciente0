using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletDuration = 2;
    public ParticleSystem hitEffect;

    private void Start()
    {
        StartCoroutine(DestroyAfterTime());
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(bulletDuration);
        Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.isTrigger && !collider.CompareTag("Water") && !collider.CompareTag("Player"))
        {
            if (!collider.CompareTag("Zombie"))
                Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
