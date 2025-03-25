using UnityEngine;

namespace InventoryProject.Util
{
    public class Define : MonoBehaviour
    {
        public class Path
        {
            public const string Player = "Character/Player";
            public const string Material = "Material/";
            public const string UI = "UI/";
            public const string SO_Item = "SO/Item";
        }
        
        public enum UIType
        {
            UI,
            Popup,
            Top,
        }

        public enum StatType
        {
            Atk,
            MaxHp,
            MagAtk,
            Def,
        }

        public enum ItemIconMaterial
        {
            None,
            Equip,
        }
    }
}