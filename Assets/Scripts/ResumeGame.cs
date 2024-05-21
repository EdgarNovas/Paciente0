using UnityEngine;

public class ResumeGame : MonoBehaviour
{ 
    public void Resume()
    {
        print("AAAAAAAAAa");

            MenuDePausa.pausa.active = false;
            MenuDePausa.pausa.TogglePauseMenu();
       
    }
}
