using PlayerSystem.Model;
using UnityEngine;
using Zenject;

namespace PlayerSystem.View
{
    public abstract class PlayerComponent : MonoBehaviour
    {
        [Inject] protected Player Player;

        protected virtual void OnPlayerStateChanged(PlayerState state) { }
    }
}