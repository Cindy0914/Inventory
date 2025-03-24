using InventoryProject.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace InventoryProject.UI
{
    public class MainButtons : UIBase
    {
        [SerializeField] private Button statusButton;
        [SerializeField] private Button inventoryButton;
        
        public override void Init(params object[] param)
        {
            statusButton.onClick.AddListener(() => UIManager.Instance.ShowUI<Status>());
            inventoryButton.onClick.AddListener(() => UIManager.Instance.ShowUI<Inventory>());
        }
    }
}