using ProjectTDS.Unit.Player;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace ProjectTDS.Unit.Enemy.StateMachine
{
    public class PursuitState : State
    {
        private EnemyInputComponent _unit;
        private NavMeshAgent _agent;

        private PlayerUnitComponent _playerUnit;

        public PursuitState(EnemyInputComponent unit, NavMeshAgent agent)
        {
            _unit = unit;
            _agent = agent;
        }

        public override void Enter()
        {
            if(_unit.EnemyFOV.CanSeePlayer) _playerUnit = _unit.EnemyFOV.Player;
            else _unit.StateMachine.ChangeState(_unit.IdleState);
        }

        public override void Exit() 
        { 
            
        }

        public override void Update()
        {
            if (_playerUnit != null)
            {
                _agent.SetDestination(_playerUnit.transform.position);
            }

            if (!_unit.EnemyFOV.CanSeePlayer) OnLostPlayer();

            float distanceToPlayer = Vector3.Distance(_unit.transform.position, _playerUnit.transform.position);

            if (distanceToPlayer < _unit.FireDistance) 
                _unit.StateMachine.ChangeState(_unit.ShootState);
        }   
        
        private async void OnLostPlayer()
        {           
            await Task.Delay((int)_unit.LossPlayerDuration * 1000);

            if (_unit.EnemyFOV.Player != null) return;

            _playerUnit = null;
            _unit.StateMachine.ChangeState(_unit.IdleState);
        }
    }
}
