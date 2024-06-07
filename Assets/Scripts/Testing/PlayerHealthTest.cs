using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthTest : MonoBehaviour
{
    [SerializeField]
    private float Points = 5f;
    [SerializeField]
    private TestType type;
    
    private void OnTriggerEnter(Collider other)
    {
        switch (type)
        {
            case TestType.ArmorRepair:
                if(other.TryGetComponent(out IRepairArmor armor))
                {
                    armor.OnArmorRepair(Points);
                }
                break;
            case TestType.HealthRepair:
                if (other.TryGetComponent(out IRepairHealth health))
                {
                    health.OnHealthRepair(Points);
                }
                break;
            case TestType.HealthHit:
                if (other.TryGetComponent(out ICanBeHit hit))
                {
                    hit.OnHealthGetDamage(Points);
                }
                break;
        }
    }

    private enum TestType
    {
        ArmorRepair,
        HealthRepair,
        HealthHit
    }

}


