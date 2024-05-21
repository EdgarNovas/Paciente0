using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDePausa : MonoBehaviour
{
    public static MenuDePausa pausa;
    
    public GameObject menuDePausa;
	public GameObject controls;
	public bool active;
	public bool ControlsActive;


    void Awake()
    {
        if (pausa == null)
        {
            pausa = this;
        }
        else if (pausa != this)
        {
            Destroy(gameObject);
        }
    }

  
    void Start()
    {
        menuDePausa.SetActive(false);
        active = false;

		controls.SetActive(false);
		ControlsActive = false;
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            active = !active;
            TogglePauseMenu();

            if(ControlsActive == true)
            {
                controls.SetActive(false);
                ControlsActive = false;
			}
        }
    }

    public void TogglePauseMenu()
    {
        if (active)
        {
            menuDePausa.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            menuDePausa.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }

	public void MenuControls()
	{
		if (ControlsActive)
		{
			controls.SetActive(true);
			Time.timeScale = 0f;
		}
		else
		{
			controls.SetActive(false);
		}
	}
}
