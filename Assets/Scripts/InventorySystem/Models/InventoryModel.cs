using System;
using System.Collections.Generic;

namespace InventorySystem.Models
{
    [Serializable]
    public class InventoryModel
    {
        public Dictionary<string, ResourceModel> Resources { get; private set; }

        public InventoryModel()
        {
            // Testing resources (next step - load this from file)
            Resources = new Dictionary<string, ResourceModel>()
            {
                {"Stone", new ResourceModel() { resourceName = "Stone", quantity = 10 }},
                {"Wood", new ResourceModel() { resourceName = "Wood", quantity = 10 }}
            };
        }
    }
}