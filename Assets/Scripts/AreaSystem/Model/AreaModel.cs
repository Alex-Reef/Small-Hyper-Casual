using System;
using InventorySystem.Models;

namespace AreaSystem.Model
{
    [Serializable]
    public class AreaModel
    {
        public bool isOpened = false;
        public KeyValue<ResourceModel, int> needResource;

        public AreaModel(string resourceName, int needForOpen)
        {
            needResource = new KeyValue<ResourceModel, int>()
            {
                key = new ResourceModel(resourceName),
                value = needForOpen
            };
        }
    }
}