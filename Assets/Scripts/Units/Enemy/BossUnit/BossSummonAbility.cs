using ProjectTDS.Unit.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace ProjectTDS.Unit.Enemy.BossAbilities
{
    public class BossSummonAbility : BossAbility
    {
        [Inject]
        private PlayerUnitComponent _unit;

        [SerializeField]
        private List<GameObject> _summonEnemy;
        [SerializeField]
        private List<Transform> _summonSpawnPoints;
        
        [Space,SerializeField,Range(1,4)]
        private int _summonCount;
        [SerializeField, Range(5,10)]
        private float _timeToSummon = 5f;

        [Space,SerializeField]
        private List<GameObject> _summonsEnemies;

        public override void UseAbility()
        {
            StartCoroutine(SummonsEnemies());
        }    

        private IEnumerator SummonsEnemies()
        {
            yield return new WaitForSeconds(_timeToSummon);

            for(int i = 0; i < _summonCount; i++)
            {
                int randomEnemyIndex = Random.Range(0, _summonEnemy.Count - 1);
                GameObject enemy = Instantiate(_summonEnemy[randomEnemyIndex], _summonSpawnPoints[i].position, Quaternion.identity);
                enemy.TryGetComponent(out NavMeshAgent enemyAgent);
                enemyAgent.SetDestination(_unit.transform.position);
                _summonsEnemies.Add(enemy);
                yield return null;
            }
        }
        
    }
}
