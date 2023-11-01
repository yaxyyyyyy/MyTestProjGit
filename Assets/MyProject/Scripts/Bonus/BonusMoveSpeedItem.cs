//using BonusSpeed;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
//using System.Diagnostics;
using UnityEditor;
using UnityEngine;
//using static UnityEngine.GraphicsBuffer;

public class BonusMoveSpeedItem : BonusItem
{
    [SerializeField] private float _newSpeed;
    [SerializeField] private float _timeBonus;
    //private StateMachine _machine;

    private void Start()
    {
        //_machine = gameObject.AddComponent<StateMachine>();
        //_machine.CreateStateMachine(new BonusSpeed.StateSleep(), new BonusSpeed.StateSwitcherSpeed());
    }
    private void OnCollisionEnter(Collision collision)
    {
        this.EntryToPool();
        GetBonus(collision.gameObject);
    }
    public new void GetBonus(GameObject targetBonus)
    {
        var move = targetBonus.GetComponent<IMove>();
        if (move != null)
        {
            var bonusSpeedOnPlayer = gameObject.GetComponent<BonusSpeedOnPlayer>();
            if(bonusSpeedOnPlayer != null) 
            {
                bonusSpeedOnPlayer.CreateBonusOnPlayer(move, _newSpeed, _timeBonus);
            }
            else
            {
                bonusSpeedOnPlayer= gameObject.AddComponent<BonusSpeedOnPlayer>();
                bonusSpeedOnPlayer.CreateBonusOnPlayer(move, _newSpeed, _timeBonus);
            }

        }
    }

    //public new void GetBonus(GameObject targetBonus)
    //{
    //    Debug.Log("GetBonus");
    //    var move = targetBonus.GetComponent<IMove>();
    //    if (move != null)
    //    {
    //        Debug.Log("move != null");
    //        _oldSpeed = move.GetMoveSpeed();
    //        move.SetMoveSpeed(_newSpeed);
    //        var machine = targetBonus.GetComponent<SMBounusSpeed>();
    //        if(machine == null) 
    //        {
    //            Debug.Log("machine == null");
    //            machine = SMBounusSpeed.CreateStateMachine<SMBounusSpeed,SWBonusSpeed>
    //                (targetBonus, 
    //                new List<State>() { 
    //                    new SBonusSpeedSleep(),
    //                    new SBonusSpeedBuff(_oldSpeed,_timeBonus)},
    //                1);


    //            Debug.Log("machine.CurrentSwitcher.SwitchState");
    //            Debug.Log("Ev_EndState.AddListener");
    //        }
    //        else
    //        {
    //            ((SBonusSpeedBuff)machine.StateSwitcher.States[1]).CreateState(_oldSpeed, _timeBonus);
    //            ((SWBonusSpeed)machine.StateSwitcher).EndState(machine.StateSwitcher.States[0]);
    //        }
    //    }
    //}
    //public new void GetBonus(GameObject targetBonus)
    //{
    //    Debug.Log("GetBonus");
    //    var move = targetBonus.GetComponent<IMove>();
    //    if (move != null) 
    //    {
    //        Debug.Log("move != null");
    //        _oldSpeed = move.GetMoveSpeed();
    //        move.SetMoveSpeed(_newSpeed);

    //        var machine = targetBonus.GetComponent<StateMachineBonusSpeed>();
    //        if(machine == null)
    //        {
    //            Debug.Log("machine == null");
    //            machine = targetBonus.AddComponent<StateMachineBonusSpeed>();
    //            machine.CreateStateMachine(move, machine);

    //        }
    //        Debug.Log("machine.CurrentSwitcher.SwitchState");
    //        ((StateSwitcherSpeed)machine.CurrentSwitcher).SwitchState(new StateSleep());
    //        ((StateSwitcherSpeed)machine.CurrentSwitcher).StateHighSpeed.Ev_EndState.AddListener(EndBonus);
    //        Debug.Log("Ev_EndState.AddListener");
    //    }
    //}
    //private void EndBonus(IState state)
    //{
    //    Debug.Log("EndBonus");
    //    if (state is StateHighSpeed)
    //    {
    //        Debug.Log("state is StateHighSpeed");
    //        ((StateMachineBonusSpeed)((StateHighSpeed)state).Switcher.Machine).TargetBonus.SetMoveSpeed(_oldSpeed);
    //    }
    //}
}



/*
namespace BonusSpeed
{
    public class SMBounusSpeed:StateMachine
    {
        protected override void Update()
        {
            CurrentState.UpdateState();
        }
    }
    public class SWBonusSpeed : StateSwitcher
    {
        public override void EndState(State state)
        {
            if(state is SBonusSpeedBuff)
            { SwitchState(0); }
            if (state is SBonusSpeedBuff)
            { SwitchState(1); }
        }
    }
    public class SBonusSpeedSleep : State
    {
        public override void UpdateState() { }
    }
    public class SBonusSpeedBuff : State
    {
        public float OldSpeed { get;private set; }
        private float _currentTime;
        public SBonusSpeedBuff(float oldSpeed, float currentTime) { OldSpeed = oldSpeed; _currentTime = currentTime; }
        public void CreateState(float oldSpeed, float currentTime) { OldSpeed = oldSpeed; _currentTime = currentTime; }

        public override void UpdateState()
        {
            Debug.Log("tik");
            _currentTime -= Time.deltaTime;
            if (_currentTime <= 0) { Ev_EndState?.Invoke(this);Debug.Log("я тут"); }
        }
        public new void ExitState()
        {
            Switcher.StateMachine.OwnerStateMachine.GetComponent<IMove>().SetMoveSpeed( OldSpeed);
            base.ExitState();
        }
    }

}

*/


/*
namespace BonusSpeed
{
    public class StateMachineBonusSpeed:StateMachine
    {
        [SerializeField] private float _timeLeft => (CurrentState is StateHighSpeed) ? ((StateHighSpeed)CurrentState).CurrentTime : 0;
        public IMove TargetBonus;
        public void CreateStateMachine(IMove move, StateMachineBonusSpeed machine)
        {
            TargetBonus = move;
            var switcher = new StateSwitcherSpeed();
            base.CreateStateMachine(new StateSleep(), switcher);
            switcher.CreateSwitcher(machine, switcher);
        }
    }
    public class StateSleep : State
    { }
    public class StateHighSpeed : State
    {
        public float CurrentTime = 5;
        public float MaxTime = 5;
        public StateSwitcherSpeed Switcher;

        public StateHighSpeed(StateSwitcherSpeed switcher)
        {
            Switcher = switcher;
        }

        public new void Enter()
        {
            CurrentTime = 5;
        }
        public new void UpdateState()
        {
            Debug.Log("UpdateState " + CurrentTime);
            CurrentTime -= Time.deltaTime;
            if(CurrentTime < 0)
            { EndState(); }
        }
    }

    public class StateSwitcherSpeed : StateSwitcher
    {
        public BonusSpeed.StateHighSpeed StateHighSpeed;
        public BonusSpeed.StateSleep StateSleep;
        public void CreateSwitcher(StateMachineBonusSpeed machine, StateSwitcherSpeed switcherSpeed)
        {
            base.CreateSwitcher(machine);
            StateHighSpeed = new StateHighSpeed(switcherSpeed);
            StateSleep = new StateSleep();

        }
        public new void SwitchState(State sleep)
        {
            if (sleep is StateSleep)        {   base.SwitchState(StateHighSpeed);   }

            if (sleep is StateHighSpeed)    {   base.SwitchState(StateSleep);       }


        }
    }

}
*/