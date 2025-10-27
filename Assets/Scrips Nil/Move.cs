using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{
    [Header("MovePlayer")]
    float horitzontal;
    float vertical;
    public float speed = 10.0f;
    private Rigidbody2D body;

    [Header("Animation")]
    private Animator animator;

    private SpriteRenderer sprite;

    private Camera cam;

    Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        cam = Camera.main;
    }

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetKeyDown(KeyCode.V))
        {
            GameManager.Instance.ChangeGodMode();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Determinate direction 1,0,-1
        horitzontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Horitzontal", horitzontal);
        vertical = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Vertical", vertical);
        Velocity();

        Vector2 lookDir = mousePos - (Vector2)transform.position;

        if (lookDir.x >= 0)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }
    }

    private void Velocity()
    {
        //Velocity and direction
        body.AddForce(new Vector2(horitzontal, vertical).normalized * speed ,ForceMode2D.Force); 
            //= new Vector2(horitzontal, vertical).normalized * speed * Time.fixedDeltaTime;
    }
}
