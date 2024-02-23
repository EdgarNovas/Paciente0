using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public float viewRadius;
    [Range(0,360)]
    public float viewAngle = 5;

    public LayerMask targetMask;

    public LayerMask obstacleMask;

    public List<Transform> visibleTargets = new List<Transform>();
    float delay = 0f;
    float resetDelay = 0.2f;

    
    private void FixedUpdate()
    {
        FindVisibleTargets();
        if (delay > 0f)
        {
            delay -= Time.fixedDeltaTime;
        }
        else
        {
            delay = resetDelay;
            
        }
        
    }
    

    void FindVisibleTargets()
    {
        visibleTargets.Clear();
        Collider2D[] targetInViewRadius = Physics2D.OverlapCircleAll(TransformToV2(),viewRadius,targetMask);
        for (int i = 0; i < targetInViewRadius.Length; i++) {
            Transform target = targetInViewRadius[i].transform;
            Vector2 dirToTarget = (target.position - transform.position).normalized;
            if(Vector3.Angle(transform.right,dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector2.Distance(transform.position, target.position);

                if (!Physics2D.Raycast(transform.position, dirToTarget, dstToTarget,obstacleMask))
                {
                    visibleTargets.Add(target);
                }
            }
        }
    }

    Vector2 TransformToV2()
    {
        return new Vector2(transform.position.x, transform.position.y);
    }


    public Vector2 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.z;
        }
        return new Vector2(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad),
            Mathf.Cos(angleInDegrees * Mathf.Deg2Rad)) ;
    }

}
