using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDePausa : MonoBehaviour
{
    public static MenuDePausa pausa;
    
    public GameObject menuDePausa;
    public int active;
    public int esc;
    // Start is called before the first frame update
    void Start()
    {
        menuDePausa.SetActive(false);
        esc = 0;
        active = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && esc == 0)
        {
            menuDePausa.SetActive(true);
            Time.timeScale = 0.0f;
            esc = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && esc == 1)
        {
            menuDePausa.SetActive(false);
            Time.timeScale = 1.0f;
            esc = 0;
        }
        else if (active == 1) {
			menuDePausa.SetActive(false);
			Time.timeScale = 1.0f;
			esc = 0;
            active = 0;
		}
    }
}
