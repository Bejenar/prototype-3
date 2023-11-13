using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] patrolPoints; 
    public Transform player;
    public float moveSpeed = 2f;
    private int currentPatrolIndex = 0;
    private bool isPatrolling = true;
    private EnemyGun canSeePlayer;

    private void Awake()
    {
        canSeePlayer = FindObjectOfType<EnemyGun>();
    }
    private void Update()
    {
        if (patrolPoints == null) return;
        if (isPatrolling)
        {
            Patrol();
        }
        else
        {
            ChasePlayer();
        }
    }
    private void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPatrolIndex].position, moveSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, patrolPoints[currentPatrolIndex].position) < 0.1f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
        if (canSeePlayer.PlayerInSight)
        {
            isPatrolling = false;
            canSeePlayer.StartToShoot();
        }
    }
    private void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        if (!canSeePlayer.PlayerInSight)
        {
            isPatrolling = true;
        }
    }
    
}
