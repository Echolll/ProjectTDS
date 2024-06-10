using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTDS.Unit
{
    public class PlayerUnitComponent : Unit
    {
        protected internal PlayerSelectWeaponComponent _weapon;

        protected override void Awake()
        {            
            base.Awake();
            _weapon = GetComponent<PlayerSelectWeaponComponent>();
        }
    }
}
