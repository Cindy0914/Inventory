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
        [SerializeField] private StatHandler statHandler;
        [SerializeField] private int inventorySize;

        public int Level { get; private set; }
        public float CurrentHp { get; private set; }
        public float CurrentExp { get; private set; }
        public float Currency { get; private set; }

        public string PlayerName => playerName;
        public StatHandler StatHandler => statHandler;
        public int InventorySize => inventorySize;

        public void Init()
        {
            statHandler.Init();
            CurrentHp = statHandler.GetBaseStat(Define.StatType.MaxHp);
            Level = 10;
            CurrentExp = 50;
            Currency = 1000;
        }

        public void EquipItem(ItemData itemData)
        {
            for (int i = 0; i < itemData.EnhanceDatas.Length; i++)
            {
                var enhanceData = itemData.EnhanceDatas[i];
                statHandler.UpdateEnhancedStat(enhanceData.statType, enhanceData.baseValue, true);
            }
            
            var status = UIManager.Instance.GetUI<Status>();
            status.UpdateStatus(statHandler);
        }
        
        public void UnEquipItem(ItemData itemData)
        {
            for (int i = 0; i < itemData.EnhanceDatas.Length; i++)
            {
                var enhanceData = itemData.EnhanceDatas[i];
                statHandler.UpdateEnhancedStat(enhanceData.statType, enhanceData.baseValue, false);
            }
            
            var status = UIManager.Instance.GetUI<Status>();
            status.UpdateStatus(statHandler);
        }
    }
}