using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiesHP : MonoBehaviour
{
    [SerializeField] TypesOfZombies typesOfZombies;
    int zombieHp;

    private void Awake()
    {
        zombieHp = typesOfZombies.zombieHp;//We put the hp of the scriptable object into the scripts hp
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Bullet")//Enemy gets hit by bullet
        {
            zombieHp -= 50;
            if(zombieHp <= 0)//If zombie is dead we deactivate him and sent him back to the pool of enemies
            {
                //GET KILLED AND GO TO OBJECT POOL
            }
        }
    }
}
