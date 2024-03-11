using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    bool playerInsideRange = false;
    float secondsToStay = 2;
    float startTime;
    float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInsideRange && GameManager.Instance.GetRescuedPeople() == 3)
        {
            elapsedTime = Time.time - startTime;
            if (elapsedTime > secondsToStay)
            {
                //SceneManager.LoadScene("Escena que sea");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            startTime = Time.time;
            playerInsideRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            playerInsideRange = false;
        }
    }
}
