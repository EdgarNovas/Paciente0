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
    //public int amountBullets = 25;
    public int amountBulletsPistola = 100;
    public int amountBulletsEscopeta = 99;

	//Sonido
	private SoundManager soundManager;
    //


	[SerializeField] Transform transformPlayer;
    [field: SerializeField] public int life { get; private set; } = 100;

    private void Awake()
    {
        if(Instance != null) { return; }

        Instance = this;

		//sonido
		soundManager = FindObjectOfType<SoundManager>();
        //
	}

    
   public void AddPeople()
    {
        rescuedPeople++;
        rescueEvent.Invoke();
		//Sonido
		soundManager.seleccionAudio(6, 0.5f);
	}

    public int GetRescuedPeople()
    {
        return rescuedPeople;
    }

    public void Damage(int damage, Vector3 attackerPosition)
    {
        life -= damage;
        
        //Vector3 pushDirection = (playerRB.transform.position - attackerPosition).normalized;
        //playerRB.AddForce(pushDirection * damage * damage * pushStrength);

        if (life <= 0)
        {
            life = 0;
            SceneManager.LoadScene("GameOver");
        }
		//Sonido
		soundManager.seleccionAudio(5, 0.5f);

	}

    public void GetHealthpack()
    {
        life += 25;
        if (life > 100)
        {
            life = 100;
        }
		//Sonido
		soundManager.seleccionAudio(4, 0.5f);

	}

    public void AddAmmunition(int ammunition)
    {
        amountBulletsPistola += ammunition;
		//Sonido
		soundManager.seleccionAudio(3, 0.5f);
	}

    public Transform PlayerTransform { get { return transformPlayer; } }
}


