using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public Transform target;
    [SerializeField]float speed = 15f;
    [SerializeField] int attackingDistance;
    [SerializeField] int stoppingDistance;

    Vector3[] path;
    int targetIndex;

    //RANDOM WONDER
    float randomDegree;
    Vector2 newPath;
    float distance;
    Vector2 direction;
    public LayerMask obstacleMask;
    private float delay;
    private float resetDelay = 1.2f;
    float coolDownAttack = 1f;
    [SerializeField] TypesOfZombies typeOfZombie;

    private void Awake()
    {
        delay = resetDelay;
        coolDownAttack = typeOfZombie.cooldownResetTime;
        
    }

    private void FixedUpdate()
    {
        if(Vector2.Distance(target.position, transform.position) < 8)
        {
            PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);

            if (Vector2.Distance(target.position, transform.position) <= 4 && coolDownAttack <= 0) 
            {
                GameManager.Instance.Damage(typeOfZombie.zombieDamage);
                coolDownAttack = typeOfZombie.cooldownResetTime;

            }
        }
        else
        {
            //Get z axis
            //Choose random degree 1 to 360
            //Raycast to see if there's a wall
            //See if place is a valid point
            if (delay > 0f)
            {
                delay -= Time.fixedDeltaTime;
            }
            else
            {
                delay = resetDelay;

                randomDegree = (float)Random.Range(1, 360) * Mathf.Deg2Rad;
                distance = Random.Range(5, 20);
                RaycastHit2D hit;
                newPath.x =  Mathf.Cos(randomDegree);
                newPath.y =  Mathf.Sin(randomDegree);
                
                direction = ((TransformToV2() + newPath) - TransformToV2()).normalized;
                hit = Physics2D.Raycast(transform.position, direction, distance, obstacleMask);
                if (!hit)
                {
                    //target.position = newPath;
                    PathRequestManager.RequestPath(transform.position, TransformToV2()+ direction * distance, OnPathFound);
                }

            }
        }

        coolDownAttack -= Time.fixedDeltaTime;
    }



    public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
    {
        if (pathSuccessful && newPath.Length >= 1)
        {
            path = newPath;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }


    IEnumerator FollowPath()
    {
        Vector3 currentWaypoint = path[0];

        while (true)
        {
            if(transform.position == currentWaypoint)
            {
                targetIndex++;
                if(targetIndex >= path.Length)
                {
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
            
            yield return null;
        }
    }

    Vector2 TransformToV2()
    {
        return new Vector2(transform.position.x, transform.position.y);
    }

    public void OnDrawGizmos()
    {
        if(path != null)
        {
            for(int i = targetIndex; i < path.Length; i++)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(path[i], Vector3.one);

                if(i == targetIndex)
                {
                    Gizmos.DrawLine(transform.position, path[i]);
                }
                else
                {
                    Gizmos.DrawLine(path[i - 1], path[i]);
                }
                
            }
        }

        Gizmos.DrawLine(transform.position, transform.position + (Vector3)direction*distance);
    }

}
