using UnityEngine;

namespace ProjectTDS.Weapons
{
    public class BulletComponent : MonoBehaviour
    {
        private float _damage;
        private Rigidbody _rigibodyBullet;

        private void OnEnable() => _rigibodyBullet = GetComponent<Rigidbody>();

        public void Initialize(float damage)
        {
            _damage = damage;
        }

        public void AddForceToBullet(float force)
        {
            _rigibodyBullet.AddForce(transform.forward * force, ForceMode.Impulse);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ICanBeHit health))
            {
                health.OnHealthGetDamage(_damage);
            }

            Destroy(this.gameObject);
        }
    }
}
