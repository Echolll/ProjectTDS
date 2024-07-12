using ProjectTDS.Unit.Enemy.StateMachine;
using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Windows;

namespace ProjectTDS.Unit.Enemy
{
    public class EnemyInputComponent : BaseUnitInputComponent
    {       
        [field : SerializeField]
        public Vector3[] PatrollingPoints { get; private set; }
       
        [field : SerializeField, Range(1,5), Space]
        public float MinPauseDuration { get; private set; }
        [field : SerializeField, Range(5,10)]
        public float MaxPauseDuration { get; private set; }

        [field : SerializeField, Range(5, 15), Space]
        public float LossPlayerDuration { get; private set; }

        [field: SerializeField, Range(1, 10), Space]
        public float FireDistance { get; private set; }

        public EnemyFOVComponent EnemyFOV { get; private set; }

        public NavMeshAgent _agent { get; private set; }

        public StateMachine.StateMachine StateMachine { get; protected set; }
        public IdleState IdleState { get; protected set; }
        public PursuitState PursuitState { get; protected set; }
        public ShootState ShootState { get; protected set; }

        protected override void Awake()
        {
            base.Awake();
            EnemyFOV = GetComponent<EnemyFOVComponent>();
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            StateMachine = new StateMachine.StateMachine();
            IdleState = new IdleState(this, _agent);
            PursuitState = new PursuitState(this, _agent);
            ShootState = new ShootState(this, _agent, Owner as EnemyUnitComponent);

            StateMachine.Initialize(IdleState);
            _agent.speed = Owner._condition.MoveSpeed;
        }

        protected virtual void Update()
        {
            if(StateMachine.CurrentState != null) StateMachine.CurrentState.Update();        
            Owner._move.UpdateAnimationStates(_agent.velocity);
            Owner._sound.PlayWalkSound(_agent.velocity);
        }

        private void OnDisable() => _agent.isStopped = true;

        #region EDITOR
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (PatrollingPoints.Length == 0) return;
            foreach (var point in PatrollingPoints)
            {
                Vector3 size = new Vector3(0.25f, 5, 0.25f);
                Gizmos.color = Color.green;
                Gizmos.DrawCube(point, size);
            }
        }
#endif
        #endregion
    }
}
