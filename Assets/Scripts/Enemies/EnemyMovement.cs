using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform patrol;
    [SerializeField] private Transform player;
    [SerializeField] private float moveSpeed = 2f;

    private List<Transform> _patrolPoints = new();
    private int _currentPatrolIndex;
    private EnemyGun _canSeePlayer;

    private void Awake()
    {
        _canSeePlayer = FindObjectOfType<EnemyGun>();
        foreach (Transform child in patrol)
        {
            _patrolPoints.Add(child);
        }
    }

    private void Update()
    {
        if (_patrolPoints == null) return;
        if (_canSeePlayer.PlayerInSight)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, _patrolPoints[_currentPatrolIndex].position,
            moveSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, _patrolPoints[_currentPatrolIndex].position) < 0.1f)
        {
            _currentPatrolIndex = (_currentPatrolIndex + 1) % _patrolPoints.Count;
        }
    }

    private void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        foreach (Transform point in _patrolPoints)
        {
            Gizmos.DrawSphere(point.position, 0.2f);
        }
    }
}