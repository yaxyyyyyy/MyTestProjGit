using ShowMeleeWeapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHitBox : MonoBehaviour
{
    [SerializeField] private DamageHitBox _hitBox;
    [SerializeField] private float _currentTime;
    [SerializeField] private float _cdBeforeShow;
    [SerializeField] private float _cdShow;
    [SerializeField] private float _cdAfterShow;
    //private Vector3 _localPositionBoxDefault;
    private bool _isShow = false;

    private StateMachineMeleeWeapon _meleeWeaponMachine;
    private void Start()
    {
        _meleeWeaponMachine = new StateMachineMeleeWeapon(_hitBox, _cdBeforeShow, _cdShow, _cdAfterShow);
    }
    private void Update()
    {
        _meleeWeaponMachine.UpdateMachine();
    }

}


namespace ShowMeleeWeapon
{
    public class StateMachineMeleeWeapon : StateMachine
    {
        public DamageHitBox HitBox { get; private set; }

        public StateMachineMeleeWeapon(DamageHitBox hitBox, float cdBeforeShow = 0.3f, float cdShow = 0.2f, float cdAfterShow = 0.2f)
        {
            HitBox = hitBox;
            this.CreateMachine(
                new List<State>()
                {
                    new StateSleep(),
                    new StateBeforeshow(cdBeforeShow),
                    new StateShow(cdShow),
                    new StateAfterShow(cdAfterShow)
                },
                0);
            foreach (var state in States) { state.CreateState(this); }
            States[CurrentState].Enter();
        }
    }
    public class StateSleep : State
    {
        public override void Enter() { ((StateMachineMeleeWeapon)Machine).HitBox.gameObject.SetActive(false); }
        public override void Exit() { }
        public override void UpdateState()
        {
            if (Input.GetMouseButtonDown(0)) { Machine.SwapState(1); }
        }

    }
    public class StateBeforeshow : State
    {
        public float MaxCd;
        public float CurrentTime;
        public StateBeforeshow(float maxCd) { MaxCd = maxCd; CurrentTime = maxCd; }
        public override void Enter()    { CurrentTime = MaxCd; }

        public override void Exit()     {                      }

        public override void UpdateState()
        {
            CurrentTime -= Time.deltaTime;
            if(CurrentTime < 0 ) { Machine.SwapState(2); }
        }
    }

    public class StateShow : State
    {
        float MaxCd;
        float CurrentTime;
        public StateShow(float maxCd) { MaxCd = maxCd; CurrentTime = maxCd; }
        public override void Enter()
        {
            CurrentTime = MaxCd;
            ((StateMachineMeleeWeapon)Machine).HitBox.gameObject.SetActive(true);
        }

        public override void Exit()
        {
            ((StateMachineMeleeWeapon)Machine).HitBox.gameObject.SetActive(false);
        }

        public override void UpdateState()
        {
            CurrentTime -= Time.deltaTime;
            if (CurrentTime < 0) { Machine.SwapState(3); }
        }
    }
    public class StateAfterShow : StateBeforeshow
    {

        public StateAfterShow(float maxCd) : base(maxCd) { }

        public override void UpdateState()
        {
            CurrentTime -= Time.deltaTime;
            if (CurrentTime < 0) { Machine.SwapState(0); }
        }
    }





}


