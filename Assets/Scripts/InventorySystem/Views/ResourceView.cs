using InventorySystem.ViewModels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem.Views
{
    public class ResourceView : MonoBehaviour
    {
        [SerializeField] private Image resourceIcon;
        [SerializeField] private TMP_Text resourceQuantityText;

        private ResourceViewModel _viewModel;
        
        public void Init(ResourceViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += OnPropertyChanged;
            OnPropertyChanged();
            
            if(ResourceListView.Instance.GetResourceData(_viewModel.ResourceName, out var model))
            {
                resourceIcon.sprite = model.resourceIcon;
            }
        }

        private void OnDestroy()
        {
            _viewModel.PropertyChanged -= OnPropertyChanged;
        }

        private void OnPropertyChanged()
        {
            resourceQuantityText.text = _viewModel.Quantity.ToString();
        }
    }
}