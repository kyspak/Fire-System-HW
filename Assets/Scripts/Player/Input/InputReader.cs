using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class InputReader : MonoBehaviour, IInputService
    {
        [SerializeField] private InputActionAsset _actions;

        public event Action OnFire;
        
        private InputAction _attackAction;

        private void Awake()
        {
            var playerMap = _actions.FindActionMap("Player");
            _attackAction = playerMap["Attack"];
        }

        private void OnEnable()
        {
            if (_attackAction != null)
            {
                _attackAction.performed += OnAttackPerformed;
                _attackAction.Enable();
            }
        }

        private void OnDisable()
        {
            if (_attackAction != null)
            {
                _attackAction.performed -= OnAttackPerformed;
                _attackAction.Disable();
            }
        }

        private void OnAttackPerformed(InputAction.CallbackContext context)
        {
            OnFire?.Invoke();
        }
    }
}