using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI personRescued;

    private void Awake()
    {
        personRescued.text = GameManager.Instance.rescuedPeople.ToString();
        GameManager.Instance.rescueEvent.AddListener(PeopleHasBeenRescued);
    }


    void PeopleHasBeenRescued()
    {
        personRescued.text = GameManager.Instance.rescuedPeople.ToString();
    }



}