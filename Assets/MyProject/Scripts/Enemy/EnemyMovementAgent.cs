using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementAgent : MonoBehaviour, IMove
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private NavMeshAgent _agent;
    public Transform PlayerTransform => _playerTransform;
    public NavMeshAgent Agent => _agent;

    //TODO переделать в машину состояний
    public bool IsWatchPlayerPositionEveryFrame = true;
    public Vector3 TargetVector;

    public void CreateEnemyMovementAgent(Transform target)
    {
        _playerTransform = target;
        TargetVector = gameObject.transform.position;
    }


    void Update()
    {
        if (IsWatchPlayerPositionEveryFrame) { _agent.SetDestination(_playerTransform.position); }
        else { _agent.SetDestination(TargetVector); }
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
