using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTDS.Interactables
{
    public class SecretDoor : MonoBehaviour
    {
        [SerializeField]
        private List<InterctableButton> _buttons;

        [Space, SerializeField]
        private Transform _openPos;
        [SerializeField]
        private float _openSpeed = 2f;

        private void OnEnable()
        {
            foreach (var button in _buttons) button.ButtonIsActiveEventHandler += CheckAllButtonIsActive;
        }

        private void OnDisable()
        {
            foreach (var button in _buttons) button.ButtonIsActiveEventHandler -= CheckAllButtonIsActive;
        }

        private void CheckAllButtonIsActive()
        {
            foreach (var button in _buttons)
            {
                if (button.Activate) continue;
                else return;
            }

            StartCoroutine(OpenSecretDoor());
        }

        private IEnumerator OpenSecretDoor()
        {
            while (Vector3.Distance(transform.position, _openPos.position) >= 0.5f)
            {
                transform.position = Vector3.Lerp(transform.position, _openPos.position, Time.deltaTime * _openSpeed);
                yield return null;
            }

            transform.position = _openPos.position;
        }
    }
}