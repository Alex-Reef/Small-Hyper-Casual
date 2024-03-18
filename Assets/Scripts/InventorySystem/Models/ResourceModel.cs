using System;

namespace InventorySystem.Models
{
    [Serializable]
    public class ResourceModel
    {
        public string resourceName;
        public int quantity;

        public ResourceModel(){}
        public ResourceModel(string resourceName)
        {
            this.resourceName = resourceName;
        }
    }
}