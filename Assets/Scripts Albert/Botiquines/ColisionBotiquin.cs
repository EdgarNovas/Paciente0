using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionBotiquin : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Curar")
        {
            GameManager.Instance.GetHealthpack();
        }

        if (collision.gameObject.CompareTag("Ammunition"))
        {
            GameManager.Instance.AddAmmunition(30);
        }
    }
}
