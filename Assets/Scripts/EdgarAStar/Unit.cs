using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    NavMeshAgent agent;
    Animator animator;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        delay = resetDelay;
        coolDownAttack = typeOfZombie.cooldownResetTime;
        target= GameManager.Instance.PlayerTransform;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = typeOfZombie.zombieSpeed;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = typeOfZombie.zombieSpeed;
    }

    private void FixedUpdate()
    {
        if(Vector2.Distance(target.position, transform.position) < 10f)
        {
            //PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
            agent.SetDestination(target.position);
            
            if (Vector2.Distance(target.position, transform.position) <= 1f && coolDownAttack <= 0) 
            {
                animator.SetTrigger("CanDamage");
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

                randomDegree = Random.Range(1, 360) * Mathf.Deg2Rad;
                distance = Random.Range(3,5);
                RaycastHit2D hit;
                newPath.x =  Mathf.Cos(randomDegree);
                newPath.y =  Mathf.Sin(randomDegree);
                
                direction = ((TransformToV2() + newPath) - TransformToV2()).normalized;
                hit = Physics2D.Raycast(transform.position, direction, distance, obstacleMask);
                if (!hit)
                {
                    //target.position = newPath;
                    //PathRequestManager.RequestPath(transform.position, TransformToV2()+ direction * distance, OnPathFound);
                    agent.SetDestination(TransformToV2() + direction * distance);
                }

            }
            
        }
        coolDownAttack -= Time.fixedDeltaTime;

        if (agent.velocity.x > 0.5f || agent.velocity.y > 0.5f)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

        
        if (target.position.x - transform.position.x < 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
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
