using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDePausa : MonoBehaviour
{
    public static MenuDePausa pausa;
    
    public GameObject menuDePausa;
    public bool active;

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
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            active = !active;
            TogglePauseMenu();
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
}
