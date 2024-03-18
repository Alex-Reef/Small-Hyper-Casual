using AreaSystem.Model;
using AreaSystem.ViewModel;
using UnityEngine;
using UnityEngine.AI;

namespace AreaSystem.Services
{
    public class AreaManager : MonoBehaviour
    {
        [SerializeField] private NavMeshSurface surface;
        
        public AreaListViewModel ViewModel { get; private set; }

        private void Awake()
        {
            ViewModel = new AreaListViewModel(new AreaListModel());
            ViewModel.AreaOpened += UpdateSurface;
        }

        private void OnDestroy()
        {
            ViewModel.AreaOpened -= UpdateSurface;
        }

        private void UpdateSurface()
        {
            surface.BuildNavMesh();
        }
    }
}