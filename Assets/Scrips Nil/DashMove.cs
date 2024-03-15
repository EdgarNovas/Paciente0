using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class DashMove : MonoBehaviour
{
    [Header("Dash")]

    public float dashSpeed;

    Rigidbody2D rb;

    Vector2 centerPos = new Vector2 (0.5f, 0.5f);

    public BoxCollider2D normalColision;
    public BoxCollider2D dashColision;
    bool dash;
    float contador;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashColision.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            contador = 0;
            dash = true;
            //BoxCollider2D1 NO
            normalColision.enabled = false;
            //BoxCollider2D2 SI
            dashColision.enabled = true;
            //Mouse Position
            Vector2 direction = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            //Move direction
            direction = direction - centerPos;
            direction = direction.normalized;
            //Dash
            rb.AddForce( direction * dashSpeed,ForceMode2D.Impulse);

        }

        if (dash) 
        {
            contador += Time.deltaTime;

            if (contador > 1f)
            {
                dash = false;
                normalColision.enabled = true;
                dashColision.enabled = false;
            }
        }
    }
}
