using System;
using System.Collections;

using AreaSystem.Model;
using AreaSystem.Services;
using AreaSystem.ViewModel;
using DG.Tweening;
using InventorySystem.Models;
using InventorySystem.Services;
using InventorySystem.ViewModels;

using UnityEngine;
using Zenject;

namespace AreaSystem.View
{
    [RequireComponent(typeof(SphereCollider))]
    public class AreaView : MonoBehaviour
    {
        [SerializeField] private ResourceTypeModel resourceTypeModel;
        [SerializeField] private int needToOpen;
        [SerializeField] private AreaProgressView areaProgressView;
        [SerializeField] private GameObject nextArea;
        
        [Inject] private Inventory _inventory;
        [Inject] private AreaManager _areaManager;
        
        public event Action AreaOpened;

        private ResourceViewModel _resourceViewModel;
        private AreaViewModel _areaViewModel;
        
        private Vector3 _nextAreaStartPos;

        private bool _lockActive;
        private Coroutine _lockCoroutine;
        
        private bool _playerInsideArea;

        private void Start()
        {
            _lockActive = true;
            var resourceName = resourceTypeModel.resourceName;
            AreaModel model = new AreaModel(resourceName, needToOpen);
            
            _areaViewModel = _areaManager.ViewModel.BindArea(this, model);
            _resourceViewModel = _areaViewModel.Resources.key;
            
            if (nextArea)
            {
                ActiveArea(_areaViewModel.IsOpened);
                _nextAreaStartPos = nextArea.transform.localPosition;
                Vector3 pos = _nextAreaStartPos;
                pos.y -= nextArea.transform.localScale.y * 2;
                nextArea.transform.localPosition = pos;
            }

            areaProgressView.Init(_areaViewModel);
            _areaViewModel.Resources.key.PropertyChanged += OnPropertyChanged;
            _lockActive = false;
        }

        private void OnDestroy()
        {
            if(_areaViewModel != null) _areaViewModel.Resources.key.PropertyChanged -= OnPropertyChanged;
        }

        private void ActiveArea(bool active)
        {
            if (!active)
            {
                if(_lockCoroutine != null)
                    StopCoroutine(_lockCoroutine);
                _lockCoroutine = StartCoroutine(WaitUnlock());
            }
            nextArea.SetActive(true);
        }

        private IEnumerator WaitUnlock()
        {
            yield return new WaitUntil(() => _lockActive);
            nextArea.SetActive(false);
        }

        private void OnPropertyChanged()
        {
            if (_resourceViewModel.Quantity >= needToOpen)
            {
                _areaViewModel.IsOpened = true;
                if (nextArea)
                {
                    nextArea.SetActive(true);
                    nextArea.transform.DOLocalMove(_nextAreaStartPos, 1f).SetEase(Ease.OutCirc).OnComplete(() =>
                    {
                        AreaOpened?.Invoke();
                    });
                }
                gameObject.SetActive(false);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag.Equals("Player", StringComparison.InvariantCultureIgnoreCase))
            {
                if (_resourceViewModel.Quantity < needToOpen)
                {
                    _playerInsideArea = true;
                    StartCoroutine(TakeResource());
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.gameObject.tag.Equals("Player", StringComparison.InvariantCultureIgnoreCase))
            {
                _playerInsideArea = false;
            }
        }

        private IEnumerator TakeResource()
        {
            var viewModel = _inventory.InventoryViewModel;
            if(viewModel == null)
                yield break;

            var wait = new WaitForSeconds(0.3f);
            while (_playerInsideArea)
            {
                yield return wait;
                if (viewModel.TryTake(resourceTypeModel.resourceName) && _resourceViewModel.Quantity < needToOpen)
                    _resourceViewModel.Quantity++;
            }
        }
    }
}