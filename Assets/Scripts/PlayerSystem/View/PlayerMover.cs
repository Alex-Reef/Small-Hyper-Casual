using System.Collections;
using PlayerSystem.Model;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace PlayerSystem.View
{
    public class PlayerMover : PlayerComponent
    {
        [SerializeField] private float speed;
        
        private InputAction _moveAction;

        private Vector3 _moveInput;
        private Coroutine _moveCoroutine;
        private Transform _characterTransform;
        private Transform _transform;

        private Vector3 _targetPosition;
        private NavMeshHit _hit;
        private Quaternion _targetRotation;

        private void Awake()
        {
            _transform = transform;
            _characterTransform = transform.GetChild(0);

            _moveAction = new PlayerControl().Player.Move;
            _moveAction.Enable();
            _moveAction.canceled += OnMoveActionCanceled;
            _moveAction.performed += OnMoveAction;
        }

        void LateUpdate()
        {
            if (_moveInput.magnitude > 0.1f)
            {
                _moveInput.Normalize();

                _targetPosition = _transform.position + _moveInput * speed * Time.deltaTime;
                if (NavMesh.SamplePosition(_targetPosition, out _hit, 1.0f, NavMesh.AllAreas))
                {
                    _transform.position = Vector3.MoveTowards(_transform.position, _targetPosition, speed * Time.deltaTime);
                    
                    _targetRotation = Quaternion.LookRotation(_moveInput, Vector3.up);
                    _characterTransform.rotation = Quaternion.Slerp(_characterTransform.rotation, _targetRotation, Time.deltaTime * speed);
                }
            }
        }

        private void OnMoveAction(InputAction.CallbackContext context)
        {
            var input = context.ReadValue<Vector2>();
            _moveInput.x = input.x;
            _moveInput.z = input.y;
            Player.CurrentPlayerState = PlayerState.Move;
        }

        private void OnMoveActionCanceled(InputAction.CallbackContext context)
        {
            Player.CurrentPlayerState = PlayerState.Idle;
            _moveInput = Vector3.zero;
        }

        private void OnDestroy()
        {
            _moveAction.performed -= OnMoveAction;
            _moveAction.canceled -= OnMoveActionCanceled;
            _moveAction.Disable();
        }
    }
}