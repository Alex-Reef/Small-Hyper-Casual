using System;
using PlayerSystem.Model;
using UnityEngine;

namespace PlayerSystem.View
{
    public class Player : MonoBehaviour
    {
        public event Action<PlayerState> PlayerStateChanged;
    
        private PlayerState _currentPlayerState;
        public PlayerState CurrentPlayerState
        {
            get => _currentPlayerState;
            set
            {
                if (_currentPlayerState != value)
                {
                    _currentPlayerState = value;
                    PlayerStateChanged?.Invoke(_currentPlayerState);
                }
            } 
        }
    }
}