using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtchDropItem : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private int percentSpawn;
    // Start is called before the first frame update
    void Start()
    {
        if(_health == null) { _health = gameObject.GetComponent<Health>(); }
        _health.Ev_SpawnItem.AddListener(Spawn);
    }

    public void Spawn()
    {
        if (Random.Range(0, 100) <= percentSpawn)
        {
            SpawnerAfterEnemyDead.Instance.SpawnItem(gameObject.transform);
            Debug.Log(gameObject.transform.position);
        }
    }

    //private void OnEnable()
    //{
    //    Debug.Log("health.Ev_Dead.AddListener(Spawn);");
    //    _health.Ev_Dead.AddListener(Spawn);

    //}
}
