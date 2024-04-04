using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI personRescued;
    [SerializeField] TextMeshProUGUI health;
    [SerializeField] TextMeshProUGUI NumBullets;

    private TextMeshProUGUI GetPersonRescued()
    {
        personRescued.text = GameManager.Instance.rescuedPeople.ToString();
        GameManager.Instance.rescueEvent.AddListener(PeopleHasBeenRescued);
        return personRescued;
    }

    void PeopleHasBeenRescued()
    {
        personRescued.text = GameManager.Instance.rescuedPeople.ToString();
    }



}
