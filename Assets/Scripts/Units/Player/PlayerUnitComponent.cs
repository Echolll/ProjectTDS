using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTDS.Unit.Player
{
    public class PlayerUnitComponent : Unit
    {
        private PlayerInteractionComponent _interaction;

        public PlayerInteractionComponent Interaction { get => _interaction; }

        protected override void Awake()
        {
            _interaction = GetComponent<PlayerInteractionComponent>();
            base.Awake();
        }
    }
}
