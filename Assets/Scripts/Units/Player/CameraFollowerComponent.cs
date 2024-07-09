using UnityEngine;

namespace ProjectTDS.Unit.Player
{
    public class CameraFollowerComponent : MonoBehaviour
    {       
        [SerializeField]
        private float _smoothSpeed = 5f;

        private Unit _target;

        private void Start()
        {
            _target = transform.parent.GetComponent<Unit>();
            transform.parent = null;
        }

        private void FixedUpdate()
        {
            if (_target == null) return; // todo
            Vector3 targetPosition = _target.transform.position;
            Vector3 desiredPosition = new Vector3(targetPosition.x, 0, targetPosition.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }

        #region EDITOR
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (_target == null) return;          
            Unit target = _target == null ? transform.parent.GetComponent<Unit>() : _target;
            
            Vector3 targetPos = new Vector3(target.transform.position.x, 0, target.transform.position.z);
            Gizmos.DrawSphere(targetPos, 0.1f);

            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, 0.15f);
        }
#endif
        #endregion
    }
}
