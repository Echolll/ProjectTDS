using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTDS.Unit.Player
{
    public class PlayerMoveComponent : UnitMoveComponent
    {
        PlayerInputComponent input;

        private void Start()
        {
            input = (PlayerInputComponent)Owner._controls; 
        }

        protected override void Update()
        {
            ref Vector2 position = ref input.GetMousePosition;
            Ray ray = Camera.main.ScreenPointToRay(position);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayDistance;

            if (groundPlane.Raycast(ray, out rayDistance))
            {
                Vector3 point = ray.GetPoint(rayDistance);
                LookAt(point);
            }
        }

        private void LookAt(Vector3 lookPoint)
        {
            Vector3 heightCorrectedPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
            transform.LookAt(heightCorrectedPoint);
        }

        private void FixedUpdate()
        {
            ref Vector3 movement = ref Owner._controls.MoveDirection;
            Owner._rigibody.AddForce(movement * Owner._condition.MoveSpeed / Time.deltaTime);       
        }
    }
}
