using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTDS.Unit.Player
{
    public class PlayerInteractionComponent : MonoBehaviour
    {
        [SerializeField]
        private float _interactionDistance = 3f;
        [SerializeField]
        private Transform _rayStartPoint;
        
        public void Interaction()
        {
            RaycastHit hit;
            Vector3 foward = _rayStartPoint.TransformDirection(Vector3.forward);

            if (Physics.Raycast(transform.position + new Vector3(0, 1.25f, 0), foward, out hit, _interactionDistance))
            { 
                hit.collider.TryGetComponent(out IInteractable interactable);
                if(interactable != null)
                {
                    interactable.Interactable();
                }            
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Vector3 foward = _rayStartPoint.TransformDirection(Vector3.forward);
            Gizmos.DrawRay(transform.position + new Vector3(0, 1.25f, 0), foward);
        }
    }
}
