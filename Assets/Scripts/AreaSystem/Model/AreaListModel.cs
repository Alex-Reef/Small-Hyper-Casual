using System;
using System.Collections.Generic;

namespace AreaSystem.Model
{
    [Serializable]
    public class AreaListModel
    {
        public Dictionary<string, AreaModel> Areas = new Dictionary<string, AreaModel>();
    }
}