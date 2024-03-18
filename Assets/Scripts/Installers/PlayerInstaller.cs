using PlayerSystem.View;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Player target;
    
        public override void InstallBindings()
        {
            Container.Bind<Player>().FromInstance(target).AsSingle().NonLazy();
        }
    }
}