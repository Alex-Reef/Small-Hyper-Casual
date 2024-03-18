using PlayerSystem.Model;
using UnityEngine;

namespace PlayerSystem.View
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : PlayerComponent
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            Player.PlayerStateChanged += OnPlayerStateChanged;
        }

        protected override void OnPlayerStateChanged(PlayerState state)
        {
            switch (state)
            {
                case PlayerState.Idle:
                    _animator.SetBool("Walk", false); 
                    break;
                case PlayerState.Move:
                    _animator.SetBool("Walk", true); 
                    break;
                default:
                    break;
            }
        }
    }
}