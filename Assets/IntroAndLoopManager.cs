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
        //audioSource1.PlayOneShot(audioSource1.clip);
        audioSource2.priority = 1;
	}

	void Update()
	{
		if (!audioSource1.isPlaying)
		{
			audioSource1.clip = audioSource2.clip;
			audioSource1.Play();
			audioSource1.loop = true;
		}
	}
}
