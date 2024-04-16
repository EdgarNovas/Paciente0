using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumRescued : MonoBehaviour
{
    public Sprite personIcon;
    public Sprite notRescued;
    public int numPerson;
    public Sprite changeHUDrescued()
    {
        if (GameManager.Instance.rescuedPeople >= 1 && numPerson == 1)
        {
            return personIcon; 
        }
        if (GameManager.Instance.rescuedPeople >= 2 && numPerson == 2)
        {
            return personIcon; 
        }
        if (GameManager.Instance.rescuedPeople >= 3 && numPerson == 3)
        {
            return personIcon;
        }

            return notRescued;
    }
}
