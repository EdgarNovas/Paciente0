using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI personRescued;
    [SerializeField] TextMeshProUGUI health;
    [SerializeField] TextMeshProUGUI NumBullets;
    [SerializeField] Image ImageHUDWeapon;
    [SerializeField] HUDWeapon hudWeapon;

    private void Start()
    {
        ImageHUDWeapon.sprite = hudWeapon.ComprobarArma();
    }

    private void Update()
    {
        ImageHUDWeapon.sprite = hudWeapon.ComprobarArma();
    }
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
