using UnityEngine;

public class ResumeGame : MonoBehaviour
{ 
    public void Resume()
    {
            MenuDePausa.pausa.active = false;
            MenuDePausa.pausa.TogglePauseMenu();
       
    }
}
