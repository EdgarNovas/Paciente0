using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumRescued : MonoBehaviour
{
    public Sprite personIcon;
    public Sprite notRescued;
    public int numPerson;
    public Sprite rescuedPerson()
    {
        if (GameManager.Instance.rescuedPeople == 1 && numPerson == 1)
        {
            return personIcon; 
        }
        if (GameManager.Instance.rescuedPeople == 2 && numPerson == 2)
        {
            return personIcon; 
        }
        if (GameManager.Instance.rescuedPeople == 3 && numPerson == 3)
        {
            return personIcon;
        }
        else
        {
            return notRescued;
        }


    }

    void Start()
    {
        RefreshRescuedText();
        GameManager.Instance.rescueEvent.AddListener(RefreshRescuedText);
    }
    
    void RefreshRescuedSprite()
    {
        if (rescueText != null)
        {
            rescueText.text = GameManager.Instance.rescuedPeople.ToString();
        }
    }

}
