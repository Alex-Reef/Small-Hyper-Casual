using System;
using System.Collections.Generic;
using System.Linq;
using AreaSystem.Model;
using AreaSystem.View;

namespace AreaSystem.ViewModel
{
    public class AreaListViewModel
    {
        private readonly AreaListModel _model;
        private readonly Dictionary<string, AreaViewModel> _areas;

        public event Action AreaOpened;
        public AreaListViewModel(AreaListModel model)
        {
            _model = model;
            _areas = _model.Areas.ToDictionary(
                area => area.Key, 
                area => new AreaViewModel(area.Value));
        }

        public AreaViewModel BindArea(AreaView area, AreaModel model)
        {
            var guid = area.gameObject.transform.GetHashCode().ToString();
            AreaViewModel viewModel;
            if (_areas.TryGetValue(guid, out var zoneViewModel))
            {
                viewModel = zoneViewModel;
            }
            else
            {
                viewModel = new AreaViewModel(model);
                _areas.Add(guid, viewModel);
                _model.Areas.Add(guid, model);
            }

            area.AreaOpened += () => AreaOpened?.Invoke();
            
            return viewModel;
        }
    }
}