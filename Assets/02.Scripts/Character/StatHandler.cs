using System.Collections;
using System.Collections.Generic;
using InventoryProject.Data;
using InventoryProject.Util;
using UnityEngine;
using StatType = InventoryProject.Util.Define.StatType;

namespace InventoryProject.Character
{
    public class StatHandler : MonoBehaviour
    {
        [SerializeField] private ClassData classData;
        private Dictionary<StatType, float> currentStats = new();
        private Dictionary<StatType, float> enhancedStats = new();

        public ClassData ClassData => classData;
        
        public void Init()
        {
            foreach (var stat in classData.Stats)
                currentStats[stat.statType] = stat.baseValue;

            foreach (var pair in currentStats)
                enhancedStats[pair.Key] = 0;
        }

        public float GetBaseStat(StatType statType)
        {
            if (currentStats.TryGetValue(statType, out var value))
            {
                return value;
            }
            
            Debug.LogError($"StatHandler : Not found stat type: {statType}");
            return -1;
        }
        
        public float GetEnhancedStat(StatType statType)
        {
            if (enhancedStats.TryGetValue(statType, out var value))
            {
                return value;
            }
            
            Debug.LogError($"StatHandler : Not found stat type: {statType}");
            return -1;
        }
        
        public void UpdateEnhancedStat(StatType statType, float value, bool isEquip)
        {
            if (isEquip)
                enhancedStats[statType] += value;
            else
                enhancedStats[statType] -= value;
        }
    }
}