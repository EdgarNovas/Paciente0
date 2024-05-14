using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiesHP : MonoBehaviour
{
    public TypesOfZombies typesOfZombies;
    [NonSerialized] public int zombieHp;

    private SoundManager soundManager;
    public ParticleSystem bloodEffect;

    private void Awake()
    {
        zombieHp = typesOfZombies.zombieHp;//We put the hp of the scriptable object into the scripts hp
        bloodEffect = GetComponentInChildren<ParticleSystem>();
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == "Bullet")//Enemy gets hit by bullet
        {
            bloodEffect.Play();
            soundManager.seleccionAudio(8, 0.15f);


            zombieHp -= 20;
            if (zombieHp <= 0)//If zombie is dead we deactivate him and sent him back to the pool of enemies
            {
                //GET KILLED AND GO TO OBJECT POOL
                GetComponent<Unit>().StopCoroutinePath();
                gameObject.SetActive(false);

            }
        }
    }

    void SetInactive()
    {
        gameObject.SetActive (false);
    }

    public void ResetHPZombie()
    {
        zombieHp = typesOfZombies.zombieHp;
    }
}
