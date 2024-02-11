using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float speed;
    [SerializeField] float stoppingDistance;
    // Update is called once per frame
    void Update()
    {
        Vector2 direction = player.position - transform.position;
        
        if(Vector2.Distance(player.position, transform.position)> stoppingDistance )
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            //Attack
            
        }
        
       
    }

    private void OnDrawGizmos()
    {
        

        Vector3 direction = player.position - transform.position;

        
            Gizmos.DrawRay(transform.position,direction);
       
    }

}
