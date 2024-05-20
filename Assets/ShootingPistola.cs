using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootingPistola : MonoBehaviour
{
    //CameraShake
    
    public Transform firePoint;
    public GameObject bulletPrefab;

	public float bulletForce = 20f;

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
            if (GameManager.Instance.amountBulletsPistola > 0 && (MenuDePausa.pausa.active == false && MenuDePausa.pausa.ControlsActive == false))
            {
                Shoot();
                GameManager.Instance.amountBulletsPistola--;

            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
		//Sonido
		soundManager.seleccionAudio(0, 0.5f);
	}
}
