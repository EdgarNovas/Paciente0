using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public float viewRadius;
    [Range(0,360)]
    public float viewAngle = 5;

    public LayerMask targetMask;

    public LayerMask obstacleMask;

    void FindVisibleTargets()
    {
        Collider2D[] targetsinViewRadius = new Collider2D[100]; 
        Collider2D target = Physics2D.OverlapCircle(TransformToV2(),viewRadius,targetMask);
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
