using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public Transform target;
    [SerializeField]float speed = 15f;
    [SerializeField] int attackingDistance;
    [SerializeField] int stoppingDistance;

    Vector3[] path;
    int targetIndex;

    private void FixedUpdate()
    {
        if(Vector2.Distance(target.position, transform.position) > 4)
        {
            PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
            /*
            if ()
            {
                StopCoroutine("FollowPath");
                //Attack
            }
            */
        }
        else
        {
            //Wander
        }
        
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
    }

}
