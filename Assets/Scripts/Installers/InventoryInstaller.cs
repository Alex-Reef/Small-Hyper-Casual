using InventorySystem.Services;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class InventoryInstaller : MonoInstaller
    {
        [SerializeField] private Inventory target;
    
        public override void InstallBindings()
        {
            Container.Bind<Inventory>().FromInstance(target).AsSingle().NonLazy();
        }
    }
}