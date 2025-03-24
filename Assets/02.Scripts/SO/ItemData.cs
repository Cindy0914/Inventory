using System;
using UnityEngine;
using EquipType = InventoryProject.Util.Define.EquipType;
using StatType = InventoryProject.Util.Define.StatType;

namespace InventoryProject.Data
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "SO_Data/ItemData")]
    public class ItemData : ScriptableObject
    {
        public int Id;
        public string ItemName;
        public EquipType EquipType;
        public Sprite IconSprite;
        public EnhanceData[] EnhanceDatas;
    }

    [Serializable]
    public class EnhanceData
    {
        public StatType StatType;
        public float Value;
    }
}