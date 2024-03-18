using System;
using System.Collections.Generic;
using System.Linq;
using InventorySystem.Models;

namespace InventorySystem.ViewModels
{
    public class InventoryViewModel
    {
        public event Action<ResourceViewModel> CollectionChanged;
        
        public Dictionary<string, ResourceViewModel> Resources { get; private set; }

        private readonly InventoryModel _inventoryModel;
        
        public InventoryViewModel(InventoryModel model)
        {
            _inventoryModel = model;
            Resources = _inventoryModel.Resources.ToDictionary(
                x => x.Key, 
                x => new ResourceViewModel(x.Value));
        }

        public bool TryTake(string resourceName, int quantity = 1)
        {
            if (quantity <= 0) return false;
            
            if(Resources.TryGetValue(resourceName, out var resource))
            {
                if (resource.Quantity >= quantity)
                {
                    resource.Quantity -= quantity;
                    return true;
                }
            }

            return false;
        }

        public bool AddResource(string resourceName, int quantity = 1)
        {
            if (quantity <= 0) return false;

            if (Resources.TryGetValue(resourceName, out var resource))
            {
                resource.Quantity += quantity;
            }
            else
            {
                var newResource = new ResourceModel()
                {
                    resourceName = resourceName,
                    quantity = quantity
                };
                var newView = new ResourceViewModel(newResource);
                Resources.Add(resourceName, newView);
                _inventoryModel.Resources.Add(resourceName, newResource);
                CollectionChanged?.Invoke(newView);
            }
            
            return true;
        }
    }
}