using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumRescued : MonoBehaviour
{
    public TextMeshProUGUI rescueText;

    public int rescuedPeople = 0;
    void Start()
    {
        RefreshRescuedText();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.AddPeople();
        rescuedPeople++;
        RefreshRescuedText();
    }

    void RefreshRescuedText()
    {
        if (rescueText != null)
        {
            rescueText.text = "Rescued: " + rescuedPeople.ToString();
        }
    }

}
