using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementAgent : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private NavMeshAgent _agent;

    public void CreateEnemyMovementAgent(Transform target)
    {
        _playerTransform = target;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _agent.SetDestination(_playerTransform.position);
    }
}
