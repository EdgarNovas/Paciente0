using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEscopeta : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint2;
    public Transform firePoint3;
    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    public GameObject bulletPrefab3;

    public float bulletForce = 20f;

    bool canPlaySound;
    public float shootCooldown;
    private float lastShootTime;
    public float shootInterval = 1f; 
    //Sonido
    private SoundManager soundManager;
	private void Awake()
	{
		soundManager = FindObjectOfType<SoundManager>();
	}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            if (GameManager.Instance.amountBulletsEscopeta > 0 && Time.time >= lastShootTime + shootInterval)
            {
                Shoot();
                GameManager.Instance.amountBulletsEscopeta -= 3;

            }
        }
        else if (Input.GetButton("Fire1"))
        {
            if (GameManager.Instance.amountBulletsEscopeta > 3 && Time.time >= lastShootTime + shootInterval)
            {
                Shoot();
                GameManager.Instance.amountBulletsEscopeta -= 3;
                lastShootTime = Time.time;
            }
        }



    }


    void Shoot()
    {

        canPlaySound = true;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        GameObject bullet2 = Instantiate(bulletPrefab2, firePoint2.position, firePoint2.rotation);
        GameObject bullet3 = Instantiate(bulletPrefab3, firePoint3.position, firePoint3.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up *  bulletForce, ForceMode2D.Impulse);
        rb2.AddForce(firePoint2.up *  bulletForce, ForceMode2D.Impulse);
        rb3.AddForce(firePoint3.up *  bulletForce, ForceMode2D.Impulse);

		//Sonido
		soundManager.seleccionAudio(1, 1.0f); //Pista de audio(1) y volumen(0,5)
	}
}
