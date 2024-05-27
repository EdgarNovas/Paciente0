using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathParticleSystem : MonoBehaviour
{
    float startTime;
    public float duration;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ParticleSystem>().Play();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime >= duration)
        {
            Destroy(gameObject); print("DESTROY");

        }
    }
}
