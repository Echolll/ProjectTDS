using UnityEngine;

namespace ProjectTDS.ConditionItems
{
    public class HealthKitComponent : ConditionComponent
    {
        protected override void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out IRepairHealth health))
            {
                health.OnHealthRepair(_restorePoints);
                Destroy(gameObject);
            }
        }
    }
}
