using UnityEngine;

namespace ProjectTDS.ConditionItems
{
    public class ArmorKitComponent : ConditionComponent
    {
        protected override void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out IRepairArmor armor))
            {
                armor.OnArmorRepair(_restorePoints);
                Destroy(gameObject);
            }
        }
    }
}
