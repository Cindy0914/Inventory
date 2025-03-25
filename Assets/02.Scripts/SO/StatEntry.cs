using System;
using InventoryProject.Util;

namespace InventoryProject.Data
{
    [Serializable]
    public class StatEntry
    {
        public Define.StatType statType;
        public float baseValue;
    }
}