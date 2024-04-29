using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public UnityEvent rescueEvent;

    public int rescuedPeople = 0;
    public int amountBullets = 25;




    [SerializeField] Transform transformPlayer;
    [field: SerializeField] public int life { get; private set; } = 100;

    private void Awake()
    {
        if (Instance != null) { return; }

        Instance = this;
    }


    public void AddPeople()
    {
        rescuedPeople++;
        rescueEvent.Invoke();
    }

    public int GetRescuedPeople()
    {
        return rescuedPeople;
    }

    public void Damage(int damage)
    {

        life -= damage;
        if (life <= 0)
        {
            life = 0;
            SceneManager.LoadScene("GameOver");
        }

    }

    public void GetHealthpack()
    {
        life += 25;
        if (life > 100)
        {
            life = 100;
        }

    }

    public void AddAmmunition(int ammunition)
    {
        amountBullets += ammunition;
    }

    public Transform PlayerTransform { get { return transformPlayer; } }
}


