using AreaSystem.ViewModel;
using InventorySystem.ViewModels;
using InventorySystem.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AreaSystem.View
{
    public class AreaProgressView : MonoBehaviour
    {
        [SerializeField] private Image resourceIcon;
        [SerializeField] private TMP_Text progressText;
        
        private AreaViewModel _areaViewModel;
        private ResourceViewModel _resourceViewModel;
        
        public void Init(AreaViewModel viewModel)
        {
            _areaViewModel = viewModel;
            _resourceViewModel = viewModel.Resources.key;
            _resourceViewModel.PropertyChanged += OnPropertyChanged;
            OnPropertyChanged();

            if (ResourceListView.Instance.GetResourceData(_resourceViewModel.ResourceName, out var model))
            {
                resourceIcon.sprite = model.resourceIcon;
            }
        }

        private void OnDestroy()
        {
            if(_resourceViewModel != null) _resourceViewModel.PropertyChanged -= OnPropertyChanged;
        }

        private void OnPropertyChanged()
        {
            progressText.text = $"{_resourceViewModel.Quantity} / {_areaViewModel.Resources.value}";
        }
    }
}