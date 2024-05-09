using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using JetBrains.Annotations;
using TMPro;

public class SafeZone : MonoBehaviour
{
    public Image barProgress;
    public Image barBackground;
    public TextMeshProUGUI textNumToRescue;
    public Image NumToRescue;

    float barYSpacing = 1f;
    bool playerInsideRange = false;
    float secondsToStay = 2.0f;
    float startTime;
    float elapsedTime;
    float barFilledPercentage = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        barProgress.transform.position = this.gameObject.transform.position + new Vector3(0, barYSpacing, 0);
        barBackground.transform.position = this.gameObject.transform.position + new Vector3(0, barYSpacing, 0);

        if (playerInsideRange && GameManager.Instance.GetRescuedPeople() >= 3)
        {
            barFilledPercentage = elapsedTime / secondsToStay;
            barProgress.fillAmount = barFilledPercentage; 
            elapsedTime = Time.time - startTime;
            if (elapsedTime > secondsToStay)
            {
                // Cargar la escena que sea
                SceneManager.LoadScene("Victory"); 
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && GameManager.Instance.GetRescuedPeople() >= 3)
        {
            startTime = Time.time;
            playerInsideRange = true;
            barProgress.enabled = true;
            barBackground.enabled = true;
        }
        if (collision.gameObject.CompareTag("Player") && GameManager.Instance.GetRescuedPeople() < 3)
        {
            textNumToRescue.enabled = true;
            textNumToRescue.text = GameManager.Instance.rescuedPeople.ToString() + "/3";
            NumToRescue.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            playerInsideRange = false;
            barProgress.enabled = false;
            barBackground.enabled = false;
        }

        if (collision.gameObject.CompareTag("Player") && GameManager.Instance.GetRescuedPeople() < 3)
        {
            textNumToRescue.enabled = false;
            NumToRescue.enabled = false;
        }
    }
}
