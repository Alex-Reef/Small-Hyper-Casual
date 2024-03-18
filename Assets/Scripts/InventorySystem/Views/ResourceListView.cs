using System.Collections.Generic;
using InventorySystem.Models;
using UnityEngine;

namespace InventorySystem.Views
{
    public class ResourceListView : MonoBehaviour
    {
        [SerializeField] private ResourceTypeModel[] resourceTypes;

        private readonly Dictionary<string, ResourceTypeModel> _cashedResourceTypes = new Dictionary<string, ResourceTypeModel>();

        public static ResourceListView Instance { get; private set; }
        
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            InitStorage();
        }

        private void InitStorage()
        {
            foreach (var resource in resourceTypes)
            {
                _cashedResourceTypes.Add(resource.resourceName, resource);   
            }
        }

        public bool GetResourceData(string resourceName, out ResourceTypeModel model)
        {
            return _cashedResourceTypes.TryGetValue(resourceName, out model);
        }
    }
}