using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroAndLoopManager : MonoBehaviour
{
	public AudioSource audioSource1;
	public AudioSource audioSource2;

	void Start()
	{
		// Suscribir la función al evento de finalización de reproducción del primer audio
		audioSource1.Play();
	}

	void Update()
	{
		if (!audioSource1.isPlaying)
		{
			audioSource2.Play();
		}
	}
}
