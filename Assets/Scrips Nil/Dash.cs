using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float dashDistans; //dash distants
    bool enemyColission; //colision whit enemy, bullets and oters
    bool mapColission; //colision whit objects in the map (carrs, houses, etc)
    public float coldown; //time of coldown
    Move move; //Move.cs
    private void Awake()
    {
        move = GetComponent<Move>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
