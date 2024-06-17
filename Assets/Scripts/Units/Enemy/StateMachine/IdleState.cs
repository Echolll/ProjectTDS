using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace ProjectTDS.Unit.Enemy.StateMachine
{
    public class IdleState : State
    {
        private EnemyInputComponent _unit;
        private NavMeshAgent _agent;

        private int _patrollingPointIndex = 0;
        private bool _canMove; 

        public IdleState(EnemyInputComponent unit, NavMeshAgent agent)
        {
            _unit = unit;
            _agent = agent;
        }

        public override void Enter()
        {
            if (_unit.PatrollingPoints.Length != 0)
            {
                SetIndexToDefault();
                _agent.SetDestination(_unit.PatrollingPoints[_patrollingPointIndex]);
            }
        }

        public override void Exit()
        {
            _canMove = false;
        }

        public override void Update() 
        {
            if (_unit.EnemyFOV.Player != null) _unit.StateMachine.ChangeState(_unit.PursuitState);

            if (_canMove) return;

            if(HasReachedDestination() && (_unit.PatrollingPoints.Length != 0))
            {
                NextPatrolPosition();
            }      
        }

        private void SetIndexToDefault()
        {
            if (_patrollingPointIndex >= _unit.PatrollingPoints.Length)
            {
                _patrollingPointIndex = 0;
            }
        }

        private bool HasReachedDestination()
        {
            if(!_agent.pathPending)
            {
                if(_agent.remainingDistance <= _agent.stoppingDistance)
                {
                    if(!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private async void NextPatrolPosition()
        {
            _canMove = true;
            
            SetIndexToDefault();

            float pauseDuration = Random.Range(_unit.MinPauseDuration, _unit.MaxPauseDuration);
            await Task.Delay((int)pauseDuration * 1000);

            _canMove = false;
            
            _agent.SetDestination(_unit.PatrollingPoints[_patrollingPointIndex]);
            _patrollingPointIndex++;
        }
    }
}
