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
    public float beforeShowAttak = 0.7f;
    public float showAttak = 0.2f;
    public float afterAttak = 3f;

    private void Start()
    {
        Machine = new EnemyStateMachine(Agent, 
            EnemyColliderTrigger.Ev_OnTriggerEnter, 
            DamageBox, 
            gameObject.transform,
            beforeShowAttak, 
            showAttak, 
            afterAttak);
    }

    private void Update()
    {
        Machine.UpdateMachine();
    }
}
