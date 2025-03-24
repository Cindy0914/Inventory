using System;
using UnityEngine;

namespace InventoryProject.Data
{
    [CreateAssetMenu(fileName = "ClassData", menuName = "SO_Data/ClassData")]
    public class ClassData : ScriptableObject
    {
        public string ClassName;
        public float MaxExp;
        public string Desc;
        public Stats BaseStats;
    }
    
    [Serializable]
    public class Stats
    {
        public float MaxHp;
        public float Atk;
        public float MagAtk;
        public float Def;
    }
}