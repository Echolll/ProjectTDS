using UnityEngine;

namespace ProjectTDS.ConditionItems
{
    public abstract class ConditionComponent : MonoBehaviour
    {
        [SerializeField]
        protected float _restorePoints;

        protected abstract void OnTriggerEnter(Collider other);
    }
}
