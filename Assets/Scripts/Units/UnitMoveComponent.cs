using UnityEngine;

namespace ProjectTDS.Unit
{
    public abstract class UnitMoveComponent : UnitComponent
    {      
        protected abstract void Update();

        public void UpdateAnimationStates(Vector3 currentVelocity)
        {
            var inverseVelocity = transform.InverseTransformDirection(currentVelocity / 2f);

            Owner._animator.SetBool("isMoving", currentVelocity.sqrMagnitude > 0.5f);

            Owner._animator.SetFloat("DirectionZ", Mathf.Clamp(inverseVelocity.z, -1f, 1f));
            Owner._animator.SetFloat("DirectionX", Mathf.Clamp(inverseVelocity.x, -1f, 1f));
        }
    }
}
