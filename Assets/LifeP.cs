using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeP : MonoBehaviour
{
    [field: SerializeField] public int life { get; private set; }

    private void Awake()
    {
        life = GameManager.Instance.life;
    }
}
