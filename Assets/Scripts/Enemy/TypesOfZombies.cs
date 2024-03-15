using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ZombieType", menuName ="Zombie")]
public class TypesOfZombies : ScriptableObject
{
    public int zombieHp;
    public int zombieSpeed;
    public int zombieDamage;
    public float cooldownResetTime;


}
