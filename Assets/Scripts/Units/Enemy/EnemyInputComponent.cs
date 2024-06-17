using ProjectTDS.Unit.Enemy.StateMachine;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace ProjectTDS.Unit.Enemy
{
    public class EnemyInputComponent : BaseUnitInputComponent
    {
        private EnemyFOVComponent _enemyFOV;

        private StateMachine.StateMachine _stateMachine;

        public EnemyFOVComponent EnemyFOV { get => _enemyFOV; private set => _enemyFOV = value; }

        public StateMachine.StateMachine StateMachine { get => _stateMachine; private set => _stateMachine = value; }

        public NavMeshAgent _agent;

        public IdleState IdleState;
        public PursuitState PursuitState;

        [SerializeField]
        private Vector3[] _patrollingPoints;

        public Vector3[] PatrollingPoints { get => _patrollingPoints; }
       
        [field : SerializeField, Range(1,5), Space]
        public float MinPauseDuration { get; private set; }
        [field : SerializeField, Range(5,10)]
        public float MaxPauseDuration { get; private set; }

        [field : SerializeField, Range(3, 5), Space]
        public float LossPlayerDuration { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            _enemyFOV = GetComponent<EnemyFOVComponent>();
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            _stateMachine = new StateMachine.StateMachine();
            IdleState = new IdleState(this, _agent);
            PursuitState = new PursuitState(this, _agent);

            _stateMachine.Initialize(IdleState);
        }

        private void Update()
        {
            _stateMachine.CurrentState.Update();
            Debug.Log($"Текущее состояние: {_stateMachine.CurrentState}");
        }

        #region EDITOR
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (_patrollingPoints.Length == 0) return;
            foreach (var point in _patrollingPoints)
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
