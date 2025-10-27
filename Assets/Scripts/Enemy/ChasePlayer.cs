using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float speed;
    [SerializeField] float detectingDistance;
    // Update is called once per frame
    void Update()
    {
        //float distance = Mathf.Sqrt(Mathf.Pow(direction.x, 2f) + Mathf.Pow(direction.y, 2f));

        if (Vector2.Distance(player.position, transform.position)> detectingDistance)
        {
            //Wander

        }
        else
        {
            
            
        }
        
       
    }

    private void OnDrawGizmos()
    {
        

        Vector3 direction = player.position - transform.position;

        
            Gizmos.DrawRay(transform.position,direction);
       
    }

}
