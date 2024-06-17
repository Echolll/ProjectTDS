using ProjectTDS.Unit.Player;
using System.Threading.Tasks;
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
            _playerUnit = _unit.EnemyFOV.Player;
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

            if (_unit.EnemyFOV.Player == null) OnLostPlayer();
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
