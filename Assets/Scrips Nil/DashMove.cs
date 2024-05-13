using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class DashMove : MonoBehaviour
{
	//Sonido
	private SoundManager soundManager;
	private void Awake()
	{
		soundManager = FindObjectOfType<SoundManager>();
	}
    //

	[Header("Dash")]

    public float dashSpeed;

    Rigidbody2D rb;

    Vector2 centerPos = new Vector2 (0.5f, 0.5f);

    public BoxCollider2D normalColision;
    public BoxCollider2D dashColision;
    bool dash;
    float contador;
    public float dhasCooldown;
    float lastDash;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashColision.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            if (Time.time - lastDash < dhasCooldown)
            {
                return;
            }
            lastDash = Time.time;

            contador = 0;
            dash = true;
            //BoxCollider2D1 NO
            //normalColision.enabled = false;
            //BoxCollider2D2 SI
            //dashColision.enabled = true;
            //Move direction
            float horizontalDir = Input.GetAxisRaw("Horizontal");
            float verticalDir = Input.GetAxisRaw("Vertical");
            Vector2 direction = new Vector2 (horizontalDir, verticalDir);
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
                //normalColision.enabled = true;
                //dashColision.enabled = false;
            }
		}

		//Sonido
		if (Input.GetKeyDown(KeyCode.Space) && ((Input.GetAxisRaw("Horizontal") != 0) || (Input.GetAxisRaw("Vertical") !=0)))
        {
			soundManager.seleccionAudio(7, 0.5f);
		}
    }
}
