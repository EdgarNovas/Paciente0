using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirRaton : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Camera cam;
    public ChangeGun playerGun;
    Vector2 mousePos;
    Vector2 cursorHotSpot;

    public Texture2D weaponTexture;
    public Texture2D gunTexture; // Asigna la textura del cursor en el inspector
    public Texture2D shotgunTexture; // Asigna la textura del cursor en el inspector

    private void Start()
    {
        cam = Camera.main;
        cursorHotSpot = new Vector2(weaponTexture.width / 2, weaponTexture.height / 2);
        Cursor.SetCursor(weaponTexture, cursorHotSpot, CursorMode.Auto);


    }


    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (playerGun.gunUsing == 0)
        {
            if (weaponTexture != gunTexture)// Asigna el sprite de la pistola
            {
                weaponTexture = gunTexture;

            }
        }
        else
        {
            if (weaponTexture != shotgunTexture)// Asigna el sprite de la escopeta
            {
                weaponTexture = shotgunTexture;  
            } 
        }
        cursorHotSpot = new Vector2(weaponTexture.width / 2, weaponTexture.height / 2);
        Cursor.SetCursor(weaponTexture, cursorHotSpot, CursorMode.Auto);
    }

    void FixedUpdate()
    {
        //Vector2 lookDir = mousePos - rb.position;
        Vector2 lookDir = mousePos - (Vector2)transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        //rb.rotation = angle;
        transform.rotation = new Quaternion();
        transform.Rotate(new Vector3(0, 0, angle), Space.Self);
        if (lookDir.x >=0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
			gameObject.transform.localScale = new Vector3(-1, 1, 1);
		}
	}
}
