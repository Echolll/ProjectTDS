using ProjectTDS.Unit.Player;
using System.Collections;
using UnityEngine;

namespace ProjectTDS.Unit.Enemy
{
    public class EnemyFOVComponent : MonoBehaviour
    {
        [SerializeField,Range(0, 10)]
        public float _radius;
        [SerializeField,Range(0, 360)]
        public float _angle;

        [field : SerializeField, Space]
        public PlayerUnitComponent Player { get; private set; }

        [Space,SerializeField]
        private LayerMask _targetMask;
        [SerializeField]
        private LayerMask _obstructionMask;

        public bool CanSeePlayer { get; private set; }

        private void Start()
        {           
            StartCoroutine(FOVRoutine());
        }

        private IEnumerator FOVRoutine()
        {
            WaitForSeconds wait = new WaitForSeconds(0.2f);

            while (true)
            {
                yield return wait;
                FieldOfViewCheck();
            }
        }

        private void FieldOfViewCheck()
        {
            Collider[] rangeChecks = Physics.OverlapSphere(transform.position, _radius, _targetMask);

            if (rangeChecks.Length != 0)
            {
                Transform target = rangeChecks[0].transform;
                Vector3 directionToTarget = (target.position - transform.position).normalized;

                if (Vector3.Angle(transform.forward, directionToTarget) < _angle / 2)
                {
                    float distanceToTarget = Vector3.Distance(transform.position, target.position);

                    if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, _obstructionMask))
                    {
                        CanSeePlayer = true;
                        target.TryGetComponent(out PlayerUnitComponent player);
                        Player = player;
                    }
                    else
                    {
                        CanSeePlayer = false;
                        Player = null;
                    }
                }
                else
                {
                    CanSeePlayer = false;
                    Player = null;
                }
                    
            }
            else if (CanSeePlayer)
            {
                CanSeePlayer = false;
                Player = null;
            }
                
        }
    }
}
