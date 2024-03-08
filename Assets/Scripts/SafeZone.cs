using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
 

public class SafeZone : MonoBehaviour
{
    //private Time

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && GameManager.Instance.GetRescuedPeople() == 3) 
        {
            Debug.Log("SDADASOUDASO");
        }
    }
}
