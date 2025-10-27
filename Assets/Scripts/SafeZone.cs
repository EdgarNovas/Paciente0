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
    public Bar bar;
    public TextMeshProUGUI textNumToRescue;
    public Image NumToRescue;

    float barYSpacing = -0.8f;
    float barXSpacing = -0.45f;
    bool playerInsideRange = false;
    float secondsToStay = 2.0f;
    float startTime;
    float elapsedTime;
    float barFilledPercentage = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        bar.gameObject.transform.position = this.gameObject.transform.position + new Vector3(barXSpacing, barYSpacing, 0);
        bar.gameObject.transform.position = this.gameObject.transform.position + new Vector3(barXSpacing, barYSpacing, 0);
        bar.UpdateValue(0);
        bar.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (playerInsideRange && GameManager.Instance.GetRescuedPeople() >= 3)
        {
            barFilledPercentage = elapsedTime / secondsToStay;
            int barFillAmount = (int)(barFilledPercentage * 100.0f);
            bar.UpdateValue(barFillAmount);
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
            bar.gameObject.SetActive(true);
            barFilledPercentage = 0;
            bar.UpdateValue(0);
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
            
            bar.gameObject.SetActive(false);

            if (GameManager.Instance.GetRescuedPeople() < 3)
            {
                textNumToRescue.enabled = false;
                NumToRescue.enabled = false;
            }
        }
    }
}
