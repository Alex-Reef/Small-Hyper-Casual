using InventorySystem.Services;
using InventorySystem.ViewModels;
using UnityEngine;
using Zenject;

namespace InventorySystem.Views
{
    public class ResourceViewList : MonoBehaviour
    {
        [SerializeField] private ResourceView viewPrefab;
        [SerializeField] private RectTransform viewParent;
        [Inject] private Inventory _inventory;
        
        private void Start()
        {
            _inventory.InventoryViewModel.CollectionChanged += AddResource;
            Init();
        }

        private void Init()
        {
            var resources = _inventory.InventoryViewModel.Resources;
            foreach (var resource in resources)
            {
                AddResource(resource.Value);
            }
        }

        private void OnDisable()
        {
            _inventory.InventoryViewModel.CollectionChanged -= AddResource;
        }

        private void AddResource(ResourceViewModel viewModel)
        {
            ResourceView viewItem = Instantiate(viewPrefab, viewParent);
            viewItem.Init(viewModel);
        }
    }
}