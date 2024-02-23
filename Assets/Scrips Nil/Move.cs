using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Move : MonoBehaviour
{
    float horitzontal;

    float vertical;

    public float speed = 2000.0f;

    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Determinate direction 1,0,-1
        horitzontal = Input.GetAxisRaw("Horizontal");

        vertical = Input.GetAxisRaw("Vertical");

        Velocity();
    }

    private void Velocity()
    {
        //Velocity and direction
        body.velocity = new Vector2(horitzontal, vertical).normalized * speed *   Time.fixedDeltaTime;
    }

}
