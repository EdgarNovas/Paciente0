using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI health;
    [SerializeField] TextMeshProUGUI numBullets;
    [SerializeField] Image imageHUDWeapon;
    [SerializeField] HUDWeapon hudWeapon;
    [SerializeField] NumRescued hudRescued;
    [SerializeField] Image personIcon1;
    [SerializeField] Image personIcon2;
    [SerializeField] Image personIcon3;

    private void Start()
    {
        imageHUDWeapon.sprite = hudWeapon.ComprobarArma();
        //GameManager.Instance.rescueEvent.AddListener(PeopleHasBeenRescued);
    }

    private void Update()
    {
        imageHUDWeapon.sprite = hudWeapon.ComprobarArma();
        personIcon1.sprite = hudRescued.changeHUDrescued();
    }
    private void  GetPersonRescued()
    {
        
    }

}
