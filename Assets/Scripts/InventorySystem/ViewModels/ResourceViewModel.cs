using System;
using InventorySystem.Models;

namespace InventorySystem.ViewModels
{
    public class ResourceViewModel
    {
        private readonly ResourceModel _model;

        public event Action PropertyChanged;
        
        public string ResourceName => _model.resourceName;

        public int Quantity
        {
            get => _model.quantity;
            set
            {
                if (_model.quantity != value)
                {
                    _model.quantity = value;
                    PropertyChanged?.Invoke();
                }
            }
        }
        
        public ResourceViewModel(ResourceModel model)
        {
            _model = model;
        }
    }
}