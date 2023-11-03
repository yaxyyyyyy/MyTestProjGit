using ShowEnemyMeleeWeapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMain : MonoBehaviour
{
    public EnemyMovementAgent Agent;

    public EnemyStateMachine Machine;
    public EnemyColliderTriggerEnter EnemyColliderTrigger;
    public DamageHitBox DamageBox;

    private void Start()
    {
        Machine = new EnemyStateMachine(Agent, EnemyColliderTrigger.Ev_OnTriggerEnter, DamageBox, gameObject.transform);
    }

    private void Update()
    {
        Machine.UpdateMachine();
    }
}
