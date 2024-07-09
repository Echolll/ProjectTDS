using System.Collections;
using UnityEngine;

namespace ProjectTDS.Unit.Enemy.BossAbilities
{
    public class BossShieldAbility : BossAbility
    {
        [SerializeField]
        private GameObject _shield;
        [SerializeField,Range(20,60)]
        private float _shieldDuration = 20f;

        public override void UseAbility()
        {
            _shield.SetActive(true);
            StartCoroutine(ShieldActive());
        }

        private void DeactivateAbility()
        {
            _shield.SetActive(false);
        }

        private IEnumerator ShieldActive()
        {          
            yield return new WaitForSeconds(_shieldDuration);
            DeactivateAbility();
        }
    }
}
