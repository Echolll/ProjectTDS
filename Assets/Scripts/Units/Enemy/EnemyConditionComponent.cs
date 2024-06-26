using ProjectTDS.Unit;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTDS.Unit.Enemy
{
    public class EnemyConditionComponent : UnitConditionComponent
    {
        public event Action<EnemyUnitComponent> OnEnemyDeathEventHandler;

        protected override void OnDied()
        {
            base.OnDied();
            Owner._controls.enabled = false;
            Destroy(gameObject, 10f);
            OnEnemyDeathEventHandler?.Invoke(Owner as EnemyUnitComponent);
        }
    }
}
