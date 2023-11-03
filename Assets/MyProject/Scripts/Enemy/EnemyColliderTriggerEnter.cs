using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyColliderTriggerEnter :MonoBehaviour
{
    public UnityEvent<GameObject> Ev_OnTriggerEnter;
    private void OnTriggerEnter(Collider other)
    {
        Ev_OnTriggerEnter?.Invoke(other.gameObject);
    }
}
