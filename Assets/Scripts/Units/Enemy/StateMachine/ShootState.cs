using ProjectTDS.Unit.Enemy.StateMachine;
using ProjectTDS.Unit.Player;
using ProjectTDS.Weapons;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.AI;

namespace ProjectTDS.Unit.Enemy.StateMachine
{
    public class ShootState : State
    {
        private EnemyUnitComponent _enemyUnit;
        private EnemyInputComponent _inputUnit;
        private NavMeshAgent _agent;

        private PlayerUnitComponent _playerUnit;

        public ShootState(EnemyInputComponent unit, NavMeshAgent agent, EnemyUnitComponent enemyUnit)
        {
            _inputUnit = unit;
            _agent = agent;
            _enemyUnit = enemyUnit;
        }

        public override void Enter()
        {
            _playerUnit = _inputUnit.EnemyFOV.Player;
        }

        public override void Exit() 
        {
            _agent.isStopped = false;
        }

        public override void Update() 
        {
            float distanceToPlayer = Vector3.Distance(_inputUnit.transform.position, _playerUnit.transform.position);

            if (distanceToPlayer > _inputUnit.FireDistance || !_inputUnit.EnemyFOV.CanSeePlayer)
            {
                _inputUnit.StateMachine.ChangeState(_inputUnit.PursuitState);
            }
            else
            {                           
                ShootAtPlayer();
            }
        }

        private void ShootAtPlayer()
        {
            if (_enemyUnit._weapon is EnemyFirearmWeaponSetComponent firearmWeapon)
            {
                if (!_agent.isStopped)
                    _agent.isStopped = true;

                _enemyUnit.transform.LookAt(_playerUnit.transform.position);

                firearmWeapon._weapon.OnAction();
            }
            else if (_enemyUnit._weapon is EnemyMeleeWeaponSetComponent meleeWeapon)
            {
                meleeWeapon._weapon.OnAction();
            }
        }
    }
}
