using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class ZombiesHP : MonoBehaviour
{
    public TypesOfZombies typesOfZombies;
    [NonSerialized] public int zombieHp;

    Rigidbody2D rb;
    float pushStrength = 1000;
    Vector2 pushDirection;

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
            GetComponent<Unit>().enabled = false;
            GetComponent<Unit>().StopCoroutinePath();
            pushDirection = collision.relativeVelocity.normalized;
            rb.AddForce(pushDirection * pushStrength, ForceMode2D.Impulse);
            
            //StartCoroutine("KnockBack",pushDirection);
            
            //Invoke( "Activate", .2f);
            
            if (zombieHp <= 0)//If zombie is dead we deactivate him and sent him back to the pool of enemies
            {
                //GET KILLED AND GO TO OBJECT POOL
                GetComponent<Unit>().StopCoroutinePath();
                Invoke("SetInactive", 0.1f);
            }

            
        }
    }


    void Activate()
    {
        GetComponent<Unit>().enabled = true;
        StopCoroutine("KnockBack");
    }


    IEnumerator KnockBack(Vector2 pushDirection)
    {
        GetComponent<Unit>().StopCoroutinePath();
       

        GetComponent<Unit>().enabled = true;


        yield return null;
    }



    void SetInactive()
    {
        gameObject.SetActive(false);
    }


    public void ResetHPZombie()
    {
        zombieHp = typesOfZombies.zombieHp;
    }
}
