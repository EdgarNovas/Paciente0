using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumRescued : MonoBehaviour
{
    public Sprite personIcon;
    public Sprite notRescued;
    public int numPerson;
    private GrowImage growImage;


    void Start()
    {
        growImage = GetComponent<GrowImage>();
    }
    public Sprite ChangeHUDrescued()
    {
        if (GameManager.Instance.rescuedPeople >= 1 && numPerson == 1)
        {
            growImage.OneLoop();
            return personIcon; 
        }
        if (GameManager.Instance.rescuedPeople >= 2 && numPerson == 2)
        {
            growImage.OneLoop();
            return personIcon; 
        }
        if (GameManager.Instance.rescuedPeople >= 3 && numPerson == 3)
        {
            growImage.OneLoop();
            return personIcon;
        }

            return notRescued;
    }
}
