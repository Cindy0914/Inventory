using System;
using InventoryProject.Data;
using InventoryProject.Managers;
using InventoryProject.UI;
using InventoryProject.Util;
using UnityEngine;

namespace InventoryProject.Character
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private string playerName;
        [SerializeField] private ClassData playerClass;
        [SerializeField] private int inventorySize;

        public int Level { get; private set; }
        public float CurrentHp { get; private set; }
        public float CurrentExp { get; private set; }
        public float Currency { get; private set; }
        public Stats EnhancedStats { get; private set; } = new();

        public string PlayerName => playerName;
        public ClassData PlayerClass => playerClass;
        public int InventorySize => inventorySize;

        public void Init()
        {
            CurrentHp = playerClass.BaseStats.MaxHp;
            Level = 10;
            CurrentExp = 50;
            Currency = 1000;
        }

        public void EquipItem(ItemData itemData)
        {
            for (int i = 0; i < itemData.EnhanceDatas.Length; i++)
            {
                switch (itemData.EnhanceDatas[i].StatType)
                {
                    case Define.StatType.Atk:
                        EnhancedStats.Atk += itemData.EnhanceDatas[i].Value;
                        break;
                    case Define.StatType.Hp:
                        EnhancedStats.MaxHp += itemData.EnhanceDatas[i].Value;
                        break;
                    case Define.StatType.MagAtk:
                        EnhancedStats.MagAtk += itemData.EnhanceDatas[i].Value;
                        break;
                    case Define.StatType.Def:
                        EnhancedStats.Def += itemData.EnhanceDatas[i].Value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            var status = UIManager.Instance.GetUI<Status>();
            status.UpdateStatus(playerClass.BaseStats, EnhancedStats);
        }
        
        public void UnEquipItem(ItemData itemData)
        {
            for (int i = 0; i < itemData.EnhanceDatas.Length; i++)
            {
                switch (itemData.EnhanceDatas[i].StatType)
                {
                    case Define.StatType.Atk:
                        EnhancedStats.Atk -= itemData.EnhanceDatas[i].Value;
                        break;
                    case Define.StatType.Hp:
                        EnhancedStats.MaxHp -= itemData.EnhanceDatas[i].Value;
                        break;
                    case Define.StatType.MagAtk:
                        EnhancedStats.MagAtk -= itemData.EnhanceDatas[i].Value;
                        break;
                    case Define.StatType.Def:
                        EnhancedStats.Def -= itemData.EnhanceDatas[i].Value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            
            var status = UIManager.Instance.GetUI<Status>();
            status.UpdateStatus(playerClass.BaseStats, EnhancedStats);
        }
    }
}