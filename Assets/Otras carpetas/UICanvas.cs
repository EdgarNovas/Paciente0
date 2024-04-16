using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI health;
    [SerializeField] TextMeshProUGUI numBullets;
    //[SerializeField] Image imageHUDWeapon;
    //[SerializeField] HUDWeapon hudWeapon;
    [SerializeField] NumRescued hudRescued1;
    [SerializeField] NumRescued hudRescued2;
    [SerializeField] NumRescued hudRescued3;
    [SerializeField] Image personIcon1;
    [SerializeField] Image personIcon2;
    [SerializeField] Image personIcon3;

    private void Start()
    {
        //imageHUDWeapon.sprite = hudWeapon.ComprobarArma();
        //GameManager.Instance.rescueEvent.AddListener(PeopleHasBeenRescued);
    }

    private void Update()
    {
        //imageHUDWeapon.sprite = hudWeapon.ComprobarArma();
        personIcon1.sprite = hudRescued1.changeHUDrescued();
        personIcon2.sprite = hudRescued2.changeHUDrescued();
        personIcon3.sprite = hudRescued3.changeHUDrescued();
    }
    private void  GetPersonRescued()
    {
        
    }

}
