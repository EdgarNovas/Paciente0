using UnityEngine;

public class BackControls : MonoBehaviour
{
	public void Back()
	{
		MenuDePausa.pausa.ControlsActive = false;
		MenuDePausa.pausa.MenuControls();

		MenuDePausa.pausa.active = true;
		MenuDePausa.pausa.TogglePauseMenu();


	}
}