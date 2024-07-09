using ProjectTDS.Unit.Enemy.BossAbilities;
using ProjectTDS.Unit.Enemy.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTDS.Unit.Enemy
{
    public class BossInputComponent : EnemyInputComponent
    {
        [SerializeField,Range(20,30)]
        private float _abilityCountdown;

        private BossAbility _ability;
        
        Coroutine _coroutine;
        
        protected override void Awake()
        {
            base.Awake();
            _ability = GetComponent<BossAbility>();
        }

        private void Start()
        {
            StateMachine = new StateMachine.StateMachine();
            IdleState = new IdleState(this, _agent);
            PursuitState = new PursuitState(this, _agent);
            ShootState = new ShootState(this, _agent, Owner as EnemyUnitComponent);

            StateMachine.Initialize(IdleState);
        }

        protected override void Update() 
        {
            base.Update();

            if(StateMachine.CurrentState == PursuitState && _coroutine == null)
            {
                _ability.enabled = true;
                _coroutine = StartCoroutine(abilityCountdown());
            }
        }

        private IEnumerator abilityCountdown()
        {
            _ability.UseAbility();
            yield return new WaitForSeconds(_abilityCountdown);
            _ability.enabled = false;
            _coroutine = null;

        }
    }
}
