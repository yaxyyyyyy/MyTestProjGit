using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtchDropItem : MonoBehaviour
{
    [SerializeField] private HealthEnemy _health;
    [SerializeField] private int percentSpawn;

    void Start()
    {
        if(_health == null) { _health = gameObject.GetComponent<HealthEnemy>(); }
    }
    private void OnEnable()
    {
        _health.Ev_Dead.AddListener(Spawn);
    }
    public void Spawn()
    {
        if (Random.Range(0, 100) <= percentSpawn)
        {
            Debug.Log("HealtchDropItem - " + gameObject.transform.position);
            var item = SpawnerAfterEnemyDead.Instance.SpawnItem(gameObject.transform);
            //Debug.Log(gameObject.transform.position);
        }
        else
        {
            Debug.Log("none HealtchDropItem - " + gameObject.transform.position);
        }
    }

}
