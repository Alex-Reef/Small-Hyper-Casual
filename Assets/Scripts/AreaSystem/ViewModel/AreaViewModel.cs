using System;
using AreaSystem.Model;
using InventorySystem.ViewModels;

namespace AreaSystem.ViewModel
{
    public class AreaViewModel
    {
        public event Action PropertyChanged;
        
        private readonly AreaModel _model;
        
        public bool IsOpened
        {
            get => _model.isOpened;
            set
            {
                if (_model.isOpened != value)
                {
                    _model.isOpened = value;
                    PropertyChanged?.Invoke();
                }
            }
        }

        public KeyValue<ResourceViewModel, int> Resources { get; private set; }

        public AreaViewModel(AreaModel model)
        {
            _model = model;
            Resources = new KeyValue<ResourceViewModel, int>()
            {
                key = new ResourceViewModel(_model.needResource.key),
                value = model.needResource.value
            };
        }      
    }
}