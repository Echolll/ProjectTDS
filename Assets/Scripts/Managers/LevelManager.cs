using ProjectTDS.Unit.Enemy;
using ProjectTDS.Unit.Player;
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
            
            if (_enemyCount.Count <= 0) OnLevelOver();
        }

        private void PlayerElimineted()
        {
            if (_player == null) OnLevelOver();
        }

        private void OnLevelOver()
        {
            StartCoroutine(SlowingTime());
            Debug.LogWarning("Игра окончена!");
        }

        private IEnumerator SlowingTime()
        {
            while(Time.timeScale > 0.1f)
            {
                yield return null;
                Time.timeScale -= 0.1f;
            }
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
