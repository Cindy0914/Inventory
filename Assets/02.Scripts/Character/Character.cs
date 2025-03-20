using InventoryProject.Data;
using UnityEngine;

namespace InventoryProject.Character
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private string characterName;
        [SerializeField] private ClassData Class;

        private float currentHp;
        private float currentExp;
        private float currency;
        
        public void Init()
        {
            currentHp = Class.maxHp;
            currentExp = 0;
            currency = 0;
        }
    }
}