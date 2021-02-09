using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public GameObject Player;
    public float FollowDistance = 20.0f;
    public float AttackDistance = 10.0f;    
    public float maxAngle = 60.0f;
    private int currentControlPointIndex = 0;
    public float damage=30.0f;
    Vector3 destination;
    void MoveToNextPatrolPoint()
    {
        if (patrolPoints.Length > 0)
        {
            destination = patrolPoints[currentControlPointIndex].position;

            currentControlPointIndex++;
            currentControlPointIndex %= patrolPoints.Length;
        }
    }

    void Awake()
    {
        MoveToNextPatrolPoint();
    }

    void Update()
    {
        if (CanMove)
        {
            float dist = Vector3.Distance(Player.transform.position, this.transform.position);

            Vector3 targetDir = Player.transform.position - transform.position;
            Vector3 forward = transform.forward;
            float angle = Vector3.SignedAngle(targetDir, forward, Vector3.up);           

            bool patrol = false;
            bool follow = (dist < FollowDistance && angle < 60);

            if (follow)
            {
                if (dist < AttackDistance)
                {
                    transform.LookAt(Player);
                    shoot = true;
                }

                GoToPlayer();
            }

            patrol = !follow && !shoot && patrolPoints.Length > 0;

            if (patrol)
            {
                if (GetDistanceToWP() < 0.5f)
                    MoveToNextPatrolPoint();
            }
        }
        if(shoot)
        {
            Player.GetComponent<HitManagment>().GetHit(damage);
        }
    }
}
