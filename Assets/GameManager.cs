using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int rescuedPeople = 0;

    [field: SerializeField] public int life { get; private set; } = 100;

    private void Awake()
    {
        if(Instance != null) { return; }

        Instance = this;
    }

    
   public void AddPeople()
    {
        rescuedPeople++;
    }


    public void Damage(int damage)
    {
        life -= damage;
        
    }

    public void GetHealthpac()
    {
        life++;

        if (life == 4)
        {
            life = 4;
        }
    }

}
