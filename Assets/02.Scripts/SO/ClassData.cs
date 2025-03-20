using System;
using UnityEngine;

namespace InventoryProject.Data
{
    [CreateAssetMenu(fileName = "ClassData", menuName = "SO_Data/ClassData")]
    [Serializable]
    public class ClassData : ScriptableObject
    {
        public string className;
        public float maxHp;
        public float atk;
        public float magAtk;
        public float def;
        public float maxExp;
        public string desc;
    }
}