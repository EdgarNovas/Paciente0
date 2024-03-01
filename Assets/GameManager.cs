using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public UnityEvent rescueEvent;

    public int rescuedPeople = 0;

    private void Awake()
    {
        if(Instance != null) { return; }

        Instance = this;
    }

    
   public void AddPeople()
    {
        rescuedPeople++;
        rescueEvent.Invoke();
    }


}
