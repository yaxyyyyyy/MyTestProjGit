using ShowMeleeWeapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace ShowEnemyMeleeWeapon
{

    public class EnemyStateMachine : StateMachine
    {
        public EnemyMovementAgent EnemyAgent;
        public List<StateTimer> StateTimers;//замена List<State> States;
        public EnemyStateMachine( 
            EnemyMovementAgent agent, 
            UnityEvent<GameObject> ev_onTriggerEnter, 
            DamageHitBox weaponHitBox, 
            Transform myTransform,

            float beforeShowAttak = 0.7f, float showAttak = 0.2f, float afterAttak = 3f
            )
        {
            EnemyAgent = agent;

            this.CreateMachine(
                new List<State>()
                { },
                0);
            StateTimers = new List<StateTimer>()
            {
                new StateSearchTarget(),
                new StateBeforeAtak(),
                new StateShowWeapon(),
                new StateAfterAtak()
            };

            weaponHitBox.gameObject.SetActive(false);
            ((StateSearchTarget)StateTimers[0]).CreateStateTimer(this, ev_onTriggerEnter);
            StateTimers[1].CreateStateTimer(this, beforeShowAttak, 2);
            ((StateShowWeapon)StateTimers[2]).CreateStateTimer(this, showAttak, weaponHitBox);
            ((StateAfterAtak)StateTimers[3]).CreateStateTimer(this, afterAttak, myTransform);
            //foreach (var state in States) { state.CreateState(this); }
            StateTimers[0].Enter();
        }
        public override void SwapState(int nextState) { StateTimers[CurrentState].Exit();/*Debug.Log(CurrentState + " -> " + nextState); */CurrentState = nextState; StateTimers[CurrentState].Enter(); }
        public override void UpdateMachine()
        {
            StateTimers[CurrentState].UpdateState();
        }
    }

    public class StateSearchTarget : StateTimer
    {
        //активирует след. состояние при попадании игрока в триггер
        public UnityEvent<GameObject> Ev_onTriggerEnter;
        public void CreateStateTimer(StateMachine machine, UnityEvent<GameObject> ev_onTriggerEnter )
        {
            base.CreateState(machine);
            Ev_onTriggerEnter = ev_onTriggerEnter;

        }
        public override void Enter()        { Ev_onTriggerEnter.AddListener(SearchTargetEnd); }
        public override void Exit()         { Ev_onTriggerEnter.RemoveListener(SearchTargetEnd); }
        public override void UpdateState()  { }
        private void SearchTargetEnd(GameObject go)      { Machine.SwapState(1);    }
    }

    public class StateBeforeAtak : StateTimer
    {
        //замах перед ударом
        //public override void Enter()        { base.Enter(); }
        //public override void Exit()         { base.Exit(); }
        //public override void UpdateState()  {base.UpdateState(); }
    }

    public class StateShowWeapon : StateTimer
    {
        //удар (показывает коллайдер наносящий урон врагу при попадании в триггер)
        public DamageHitBox WeaponEnemyBox;
        public void CreateStateTimer(StateMachine machine, float maxTime, DamageHitBox weaponBox)
        {
            base.CreateStateTimer(machine, maxTime,3);
            WeaponEnemyBox = weaponBox;
        }
        public override void Enter()
        {
            WeaponEnemyBox.gameObject.SetActive(true);
            base.Enter();
        }
        public override void Exit()
        {
            WeaponEnemyBox.gameObject.SetActive(false);
            base.Exit();
        }
    }

    public class StateAfterAtak : StateTimer
    {
        //враг убегает после удара пока не кончится таймер
        private Transform _transformEnemy;
        private float _panicCoef;
        public void CreateStateTimer(EnemyStateMachine machine, float maxTime, Transform transformEnemy)
        {
            _panicCoef = machine.EnemyAgent.Agent.speed * maxTime;
            _transformEnemy = transformEnemy;
            base.CreateStateTimer(machine, maxTime, 0);
        }
        public override void Enter()
        {
            ((EnemyStateMachine)Machine).EnemyAgent.IsWatchPlayerPositionEveryFrame = false;
            ((EnemyStateMachine)Machine).EnemyAgent.Agent.destination = 
                (_transformEnemy.position - 
                ((EnemyStateMachine)Machine).EnemyAgent.PlayerTransform.position).normalized * 
                _panicCoef;
        }

        public override void Exit()
        {
            ((EnemyStateMachine)Machine).EnemyAgent.IsWatchPlayerPositionEveryFrame = true;
            ((EnemyStateMachine)Machine).EnemyAgent.TargetVector = ((EnemyStateMachine)Machine).EnemyAgent.PlayerTransform.position;
            //.Agent.destination = ((EnemyStateMachine)Machine).EnemyAgent.PlayerTransform.position;
        }

        //public override void UpdateState()
        //{
        //}
    }

}
