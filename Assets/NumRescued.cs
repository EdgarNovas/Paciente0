using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumRescue : MonoBehaviour
{
    public static NumRescue Instance { get; private set; }
    public TextMeshProUGUI rescueText;

    public int rescuedPeople = 2;

    private void Awake()
    {
        if (Instance != null) { return; }

        Instance = this;
    }


    public void AddPeople()
    {
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
