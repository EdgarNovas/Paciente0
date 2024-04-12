using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumRescued : MonoBehaviour
{
    public TextMeshProUGUI rescueText;


    void Start()
    {
        RefreshRescuedText();
        GameManager.Instance.rescueEvent.AddListener(RefreshRescuedText);
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RefreshRescuedText();
    }
    */
    void RefreshRescuedText()
    {
        if (rescueText != null)
        {
            rescueText.text = "Rescued: " + GameManager.Instance.rescuedPeople.ToString();
        }
    }

}
