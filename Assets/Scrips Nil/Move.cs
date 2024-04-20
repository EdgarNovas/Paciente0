using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Determinate direction 1,0,-1
        horitzontal = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Horizontal", horitzontal);

        vertical = Input.GetAxisRaw("Vertical");

        Velocity();
    }

    private void Velocity()
    {
        //Velocity and direction
        body.AddForce(new Vector2(horitzontal, vertical).normalized * speed ,ForceMode2D.Force); 
            //= new Vector2(horitzontal, vertical).normalized * speed * Time.fixedDeltaTime;
    }
}
