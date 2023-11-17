using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DirectorSpawnerEnemy : MonoBehaviour
{
    [SerializeField] private Transform _targetPlayerPosition;
    [SerializeField] private List<SpawnerEnemy> _spawnersEnemys = new List<SpawnerEnemy>();
    [SerializeField] private float _maxCoolDownSpawnEnemy = 3f;
    [SerializeField] private float _currentCooldown;

    private void Awake()
    {
        SpawnerEnemy.Ev_StartSpawner.AddListener(SetPlayerInSpawnerEnemy);
    }
    private void SetPlayerInSpawnerEnemy(SpawnerEnemy spawner)
    {
        _spawnersEnemys.Add(spawner);
        spawner.SetPlayer(_targetPlayerPosition);

    }
    private void Start()
    {
        _currentCooldown = _maxCoolDownSpawnEnemy;
        //foreach(var spawner in _spawnersEnemys)
        //{
        //    spawner.SetPlayer(_targetPlayerPosition);
        //}
    }
    private void Update()
    {
        _currentCooldown -= Time.deltaTime;
        if(_currentCooldown < 0)
        {
            if(SpawnEnemy())
            {
                _currentCooldown = _maxCoolDownSpawnEnemy;
            }
        }
    }
    private bool SpawnEnemy()
    {
        var candidats = _spawnersEnemys.Where(spawner => !spawner.IsVisible).ToList();
        if (candidats.Count > 0) 
        { 
            var item = candidats[Random.Range(0, candidats.Count - 1)].SpawnItem();
            var agent = item.GetGameObject().GetComponent<EnemyMovementAgent>();
            agent.CreateEnemyMovementAgent(_targetPlayerPosition);
            return true; 
        }
        return false;

    }
}
