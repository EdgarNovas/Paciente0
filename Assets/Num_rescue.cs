using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Num_rescue : MonoBehaviour
{
    private int num_rescue;
    // Start is called before the first frame update
    void Start()
    {
        num_rescue = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rescue")
        {

        }
    }
    // Update is called once per frame
}
