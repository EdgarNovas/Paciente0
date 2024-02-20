using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(-speed * Time.deltaTime, 0, 0); //isquierda
        }

        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(speed * Time.deltaTime, 0, 0);//derecha
        }

        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(0, speed * Time.deltaTime, 0);//arriva
        }

        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(0, -speed * Time.deltaTime, 0);//abajo
        }
    }
}
