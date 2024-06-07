using ProjectTDS.Unit.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTDS.Unit
{
    public abstract class UnitMoveComponent : UnitComponent
    {      
        protected abstract void Update();
    }
}
