using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementAgent : MonoBehaviour, IMove
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private NavMeshAgent _agent;

    public void CreateEnemyMovementAgent(Transform target)
    {
        _playerTransform = target;
    }


    void Update()
    {
        _agent.SetDestination(_playerTransform.position);
    }

    public void SetMoveSpeed(float speed)
    {
        _agent.speed = speed;
    }
    public float GetMoveSpeed()
    {
        return _agent.speed;
    }
}

public interface IMove
{
    public void SetMoveSpeed(float speed);
    public float GetMoveSpeed();
}
