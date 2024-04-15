using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiesHP : MonoBehaviour
{
    public TypesOfZombies typesOfZombies;
    [NonSerialized] public int zombieHp;

    Rigidbody2D rb;
    float pushStrength = 100;

    private void Awake()
    {
        zombieHp = typesOfZombies.zombieHp;//We put the hp of the scriptable object into the scripts hp
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Bullet")//Enemy gets hit by bullet
        {
            zombieHp -= 20;

            print(transform.position + " " + collision.transform.position);
            Debug.Log("Rigidbody2D reference: " + rb);
            Vector3 pushDirection = (transform.position - collision.transform.position).normalized;
            rb.AddForce(pushDirection * pushStrength);
            
            if (zombieHp <= 0)//If zombie is dead we deactivate him and sent him back to the pool of enemies
            {
                //GET KILLED AND GO TO OBJECT POOL
                GetComponent<Unit>().StopCoroutinePath();
                gameObject.SetActive(false);
                
            }

            
        }
    }
}
