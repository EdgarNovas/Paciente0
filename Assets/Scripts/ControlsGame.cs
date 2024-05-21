using UnityEngine;

public class ControlsGame : MonoBehaviour
{
	public void Controls()
	{
		MenuDePausa.pausa.active = false;
		MenuDePausa.pausa.TogglePauseMenu();

		MenuDePausa.pausa.ControlsActive = true;
		MenuDePausa.pausa.MenuControls();
	}
}



