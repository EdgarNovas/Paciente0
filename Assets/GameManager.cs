using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int rescuedPeople = 0;
    public int amountBullets = 25;

    [field: SerializeField] public int health { get; private set; } = 100;

    private void Awake()
    {
        if(Instance != null) { return; }

        Instance = this;
    }

    
   public void AddPeople()
    {
        rescuedPeople++;
    }

    public int GetRescuedPeople()
    {
        return rescuedPeople;
    }

    public void Damage(int damage)
    {
        health -= damage;
        
    }

    public void GetHealthpack()
    {
        health++;

        if (health == 4)
        {
            health = 4;
        }
    }
}


