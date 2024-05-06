using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirRaton : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;
    public ChangeGun playerGun;
    Vector2 mousePos;

    public Texture2D weaponTexture;
    public Texture2D gunTexture; // Asigna la textura del cursor en el inspector
    public Texture2D shotgunTexture; // Asigna la textura del cursor en el inspector

    private void Start()
    {
        cam = Camera.main;



    }


    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (playerGun.gunUsing == 0)
        {
            weaponTexture = gunTexture; // Asigna el sprite de la pistola
        }
        else if (playerGun.gunUsing == 1)
        {
            weaponTexture = shotgunTexture; // Asigna el sprite de la escopeta
        }

        Cursor.SetCursor(weaponTexture, mousePos, CursorMode.Auto);

    }

    void FixedUpdate()
    {
        //Vector2 lookDir = mousePos - rb.position;
        Vector2 lookDir = mousePos - (Vector2)transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        //rb.rotation = angle;
        transform.rotation = new Quaternion();
        transform.Rotate(new Vector3(0, 0, angle), Space.Self);
        if (lookDir.y >=0)
        {
            
        }
    }
}
