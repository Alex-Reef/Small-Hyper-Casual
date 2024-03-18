using UnityEngine;

namespace InventorySystem.Models
{
    [CreateAssetMenu(fileName = "Resource Type", menuName = "Inventory/Resource Type", order = 0)]
    public class ResourceTypeModel : ScriptableObject
    {
        public Sprite resourceIcon;
        public string resourceName;
    }
}