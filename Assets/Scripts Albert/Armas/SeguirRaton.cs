using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirRaton : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 mousePos;

    public Texture2D cursorTexture; // Asigna la textura del cursor en el inspector

    private void Start()
    {
        cam = Camera.main;

        Cursor.visible = false;
 
    }
    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Cursor.SetCursor(cursorTexture, mousePos, CursorMode.Auto);
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
