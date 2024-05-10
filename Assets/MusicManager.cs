using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
	public List<GameObject> pista = new List<GameObject>();

	public static MusicManager State;
	public int soundState = 0;

	private void Awake()
	{
		if (State != null)
			return;
		State = this;
	}

	// Update is called once per frame
	void Update()
	{
		//Bajo
		pista[0].SetActive(true);

		//Bateria
		pista[1].SetActive(true);

		//Caja
		pista[2].SetActive(true);

		//Cuerdas
		if (soundState == 0)
		{
			pista[3].SetActive(false);
		}
		else if (soundState > 0)
			pista[3].SetActive(true);


		//Acordes
		if (soundState == 0)
		{
			pista[4].SetActive(false);
		}
		else if (soundState > 0)
			pista[4].SetActive(true);
	
		//Melodia
		if (soundState == 0)
		{
			pista[5].SetActive(false);
		}
		else if (soundState > 1)
			pista[5].SetActive(true);

		//Organo
		if (soundState == 0)
		{
			pista[6].SetActive(false);
		}
		else if (soundState > 2)
			pista[6].SetActive(true);

		

	}

}


