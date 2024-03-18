using AreaSystem.Services;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class AreaManagerInstaller : MonoInstaller
    {
        [SerializeField] private AreaManager target;
    
        public override void InstallBindings()
        {
            Container.Bind<AreaManager>().FromInstance(target).AsSingle().NonLazy();
        }
    }
}