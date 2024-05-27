using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEscopeta : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform firePoint4;
    public Transform firePoint5;
    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    public GameObject bulletPrefab3;
    public GameObject bulletPrefab4;
    public GameObject bulletPrefab5;

    public float bulletForce = 20f;

    bool canShoot;
    bool canPlaySound;
    public float shootCooldown;
    float lastShoot;

    //Sonido
    private SoundManager soundManager;
	private void Awake()
	{
		soundManager = FindObjectOfType<SoundManager>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastShoot > shootCooldown - 0.5f && !canShoot)
        {
            if (canPlaySound)
            {
                int audio = UnityEngine.Random.Range(10, 13);
                soundManager.seleccionAudio(audio, 0.2f);
                canPlaySound = false;
            }

            if (Time.time - lastShoot > shootCooldown)
                canShoot = true;

        }
       
        if (canShoot && Input.GetButton("Fire1"))
        { 
            if(GameManager.Instance.amountBulletsEscopeta > 0 && (MenuDePausa.pausa.active == false && MenuDePausa.pausa.ControlsActive == false))
            {
                Shoot();
                GameManager.Instance.amountBulletsEscopeta -= 3;
            }
        }

    }


    void Shoot()
    {
        lastShoot = Time.time;
        canShoot = false;
        canPlaySound = true;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        GameObject bullet2 = Instantiate(bulletPrefab2, firePoint2.position, firePoint2.rotation);
        GameObject bullet3 = Instantiate(bulletPrefab3, firePoint3.position, firePoint3.rotation);
        GameObject bullet4 = Instantiate(bulletPrefab4, firePoint4.position, firePoint4.rotation);
        GameObject bullet5 = Instantiate(bulletPrefab5, firePoint5.position, firePoint5.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
        Rigidbody2D rb4 = bullet4.GetComponent<Rigidbody2D>();
        Rigidbody2D rb5 = bullet5.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up *  bulletForce, ForceMode2D.Impulse);
        rb2.AddForce(firePoint2.up *  bulletForce, ForceMode2D.Impulse);
        rb3.AddForce(firePoint3.up *  bulletForce, ForceMode2D.Impulse);
        rb4.AddForce(firePoint4.up *  bulletForce, ForceMode2D.Impulse);
        rb5.AddForce(firePoint5.up *  bulletForce, ForceMode2D.Impulse);

		//Sonido
		soundManager.seleccionAudio(1, 1.0f); //Pista de audio(1) y volumen(0,5)
	}
}
