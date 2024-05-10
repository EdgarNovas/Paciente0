using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
	public List<GameObject> pista = new List<GameObject>();

	public static MusicManager State;
	public int soundState = 0;

	List<AudioSource> source = new List<AudioSource>();


    private void Awake()
	{
		if (State != null)
			return;
		State = this;

		for (int i = 0; i < pista.Count; i++)
		{
            source.Add(pista[i].GetComponent<AudioSource>());
			source[i] = pista[i].GetComponent<AudioSource>();
		}

	}

	// Update is called once per frame
	void Update()
	{
		//Bajo
		source[0].volume = 1.0f;

        //Bateria
        source[1].volume = 1.0f;

        //Caja
        source[2].volume = 1.0f;

        //Cuerdas
        if (soundState == 0)
		{
            source[3].volume = 0.0f;
        }
		else if (soundState > 0)
            source[3].volume = 1.0f;

        //Acordes
        if (soundState == 0)
		{
            source[4].volume = 0.0f;
        }
		else if (soundState > 1)
            source[4].volume = 1.0f;

        //Organo
        if (soundState == 0)
        {
            source[6].volume = 0.0f;
        }
        else if (soundState > 1)
            source[6].volume = 1.0f;

        //Melodia
        if (soundState == 0)
		{
            source[5].volume = 0.0f;
        }
		else if (soundState > 2)
            source[5].volume = 1.0f;




    }

}


