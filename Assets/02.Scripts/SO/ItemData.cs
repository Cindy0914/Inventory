using UnityEngine;

namespace InventoryProject.Data
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "SO_Data/ItemData")]
    public class ItemData : ScriptableObject
    {
        public int Id;
        public string ItemName;
        public Sprite IconSprite;
        public StatEntry[] EnhanceDatas;
    }
}