using System;

namespace AreaSystem.Model
{
    [Serializable]
    public class KeyValue<TKey, TValue>
    {
        public TKey key;
        public TValue value;
    }
}