using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICanvas : MonoBehaviour
{
    [SerializeField] Bar healthBar;
    [SerializeField] Bar ammoBar;
    [SerializeField] ChangeGun playerGun;
    [SerializeField] TextMeshProUGUI health;
    [SerializeField] TextMeshProUGUI numBullets;
    [SerializeField] HUDWeapon hudWeapon1;
    [SerializeField] HUDWeapon hudWeapon2;
    [SerializeField] Image gunHUD;
    [SerializeField] Image shotgunHUD;
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
        gunHUD.sprite = hudWeapon1.CheckWeapon();
        shotgunHUD.sprite = hudWeapon2.CheckWeapon();
        healthBar.UpdateValue(GameManager.Instance.life);
        if (playerGun.gunUsing == 0)
            ammoBar.UpdateValue(GameManager.Instance.amountBulletsPistola);
        else
            ammoBar.UpdateValue(GameManager.Instance.amountBulletsEscopeta);


        personIcon1.sprite = hudRescued1.ChangeHUDrescued();
        personIcon2.sprite = hudRescued2.ChangeHUDrescued();
        personIcon3.sprite = hudRescued3.ChangeHUDrescued();
    }

}
