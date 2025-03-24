using InventoryProject.Character;
using InventoryProject.Data;
using InventoryProject.Managers;
using InventoryProject.Util;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventoryProject.UI
{
    public class Inventory : UIBase
    {
        [SerializeField] private TextMeshProUGUI itemCount;
        [SerializeField] private Transform content;
        [SerializeField] private Button returnButton;

        private int inventorySize;
        private ItemSlot[] itemSlots;
        
        public override void Init(params object[] param)
        {
            var player = param[0] as Player;
            inventorySize = player.InventorySize;
            
            itemSlots = new ItemSlot[inventorySize];
            for (int i = 0; i < inventorySize; i++)
            {
                var obj = ResourceManager.Instance.Load<ItemSlot>($"{Define.Path.UI}ItemSlot");
                var itemSlot = Instantiate(obj, content);
                itemSlot.Init();
                itemSlots[i] = itemSlot;
            }
            
            returnButton.onClick.AddListener(() => UIManager.Instance.ShowUI<MainButtons>());
        }

        public void AddItem(ItemData itemData)
        {
            var emptySlot = GetEmptySlot();
            if (emptySlot == null)
            {
                Debug.Log("Inventory is full");
                return;
            }
            
            emptySlot.AddItem(itemData);
        }
        
        private ItemSlot GetEmptySlot()
        {
            for (int i = 0; i < inventorySize; i++)
            {
                if (itemSlots[i].IsEmpty())
                {
                    return itemSlots[i];
                }
            }

            return null;
        }
    }
}