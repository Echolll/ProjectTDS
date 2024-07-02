using ProjectTDS.Unit.Enemy;
using ProjectTDS.Unit.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace ProjectTDS.Managers
{
    public class LevelManager : MonoBehaviour
    {
        [Inject]
        private PlayerUnitComponent _player;

        [SerializeField]
        private List<EnemyUnitComponent> _enemyCount;

        public event Action<bool> MissonEndEventHandler;

        private void Awake()
        {
            _enemyCount = FindObjectsOfType<EnemyUnitComponent>().ToList();
        }

        private void OnEnable()
        {
            foreach (EnemyUnitComponent enemy in _enemyCount)
            {
                var conditionEnemy = enemy._condition as EnemyConditionComponent;
                conditionEnemy.OnEnemyDeathEventHandler += EnemyElimineted;
            }

            var conditionPlayer = _player._condition as PlayerConditionComponent;
            conditionPlayer.PlayerDeathEventHandler += PlayerElimineted;
        }

        private void EnemyElimineted(EnemyUnitComponent enemy)
        {
            if(_enemyCount.Contains(enemy)) 
                _enemyCount.Remove(enemy);
            
            if (_enemyCount.Count <= 0) OnLevelOver(true);
        }

        private void PlayerElimineted()
        {
            if (_player == null) OnLevelOver(false);
        }

        private void OnLevelOver(bool playerWin)
        {
            StartCoroutine(StopTime());
            MissonEndEventHandler?.Invoke(playerWin);
        }

        private IEnumerator StopTime()
        {
            var input = _player._controls as PlayerInputComponent;
            input.enabled = false;

            yield return new WaitForSeconds(5f);

            Time.timeScale = 0f;
        }

        private void OnDestroy()
        {
            foreach (EnemyUnitComponent enemy in _enemyCount)
            {
                var conditionEnemy = enemy._condition as EnemyConditionComponent;
                conditionEnemy.OnEnemyDeathEventHandler -= EnemyElimineted;
            }

            var conditionPlayer = _player._condition as PlayerConditionComponent;
            conditionPlayer.PlayerDeathEventHandler -= PlayerElimineted;
        }

    }
}
