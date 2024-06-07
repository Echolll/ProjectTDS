using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTDS.Unit
{
    public class UnitComponent : MonoBehaviour
    {
        protected Unit Owner;

        protected virtual void Awake()
        {
            Owner = GetComponent<Unit>();
        }
    }
}
