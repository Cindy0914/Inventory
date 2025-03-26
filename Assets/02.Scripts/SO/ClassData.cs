using System;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryProject.Data
{
    // 직업별 스탯 등의 데이터를 담당
    [CreateAssetMenu(fileName = "ClassData", menuName = "SO_Data/ClassData")]
    public class ClassData : ScriptableObject
    {
        public string ClassName;
        public float MaxExp;
        public string Desc;
        public List<StatEntry> Stats;
    }
}