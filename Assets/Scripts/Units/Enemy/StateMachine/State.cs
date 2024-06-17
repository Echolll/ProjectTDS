using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTDS.Unit.Enemy.StateMachine
{
    public abstract class State
    {
        public virtual void Enter() {}

        public virtual void Exit() {}

        public virtual void Update() {}
    }
}
