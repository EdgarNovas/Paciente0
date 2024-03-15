using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionBotiquin : MonoBehaviour
{

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Curar")
        {
            GameManager.Instance.GetHealthpac();
            Destroy(collision.gameObject);
        }
    }
}
