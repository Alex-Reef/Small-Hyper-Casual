using InventorySystem.Models;
using InventorySystem.ViewModels;
using UnityEngine;

namespace InventorySystem.Services
{
    public class Inventory : MonoBehaviour
    {
        public InventoryViewModel InventoryViewModel { get; private set; }

        private void Awake()
        {
            InventoryViewModel = new InventoryViewModel(new InventoryModel());
        }
    }
}