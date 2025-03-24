using InventoryProject.Data;
using InventoryProject.Managers;
using InventoryProject.Util;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using ItemIconMaterial = InventoryProject.Util.Define.ItemIconMaterial;

namespace InventoryProject.UI
{
    public class ItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image icon;
        [SerializeField] private GameObject buttonPanel;
        [SerializeField] private Button equipButton;
        [SerializeField] private Button removeButton;
        [SerializeField] private TextMeshProUGUI equipText;
        [SerializeField] private GameObject equippedIcon;
        [SerializeField] private Outline outline;

        private ItemData itemData;
        private bool isEquipped;

        public void Init()
        {
            icon.sprite = null;
            equipText.text = "장착하기";
            icon.material = DataManager.Instance.GetMaterialData(ItemIconMaterial.None.GetName());
            SetEquipComponent(false);

            equipButton.onClick.AddListener(() =>
            {
                if (isEquipped) UnEquipItem();
                else EquipItem();
            });

            removeButton.onClick.AddListener(RemoveItem);
        }

        public void AddItem(ItemData item)
        {
            itemData = item;
            icon.sprite = item.IconSprite;
        }

        private void EquipItem()
        {
            SetEquipComponent(true);
            equipText.text = "해제하기";
            icon.material = DataManager.Instance.GetMaterialData(ItemIconMaterial.Equip.GetName());

            var player = GameManager.Instance.Player;
            player.EquipItem(itemData);
        }

        private void UnEquipItem()
        {
            SetEquipComponent(false);
            equipText.text = "장착하기";
            icon.material = DataManager.Instance.GetMaterialData(ItemIconMaterial.None.GetName());

            var player = GameManager.Instance.Player;
            player.UnEquipItem(itemData);
        }

        private void RemoveItem()
        {
            if (isEquipped)
                UnEquipItem();

            itemData = null;
            icon.sprite = null;
            buttonPanel.SetActive(false);
            equipButton.onClick.RemoveAllListeners();
            removeButton.onClick.RemoveAllListeners();
        }
        
        private void SetEquipComponent(bool isEquip)
        {
            isEquipped = isEquip;
            equippedIcon.SetActive(isEquipped);
            outline.enabled = isEquipped;
            buttonPanel.SetActive(false);
        }

        public bool IsEmpty()
        {
            return itemData == null;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (IsEmpty()) return;
            buttonPanel.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (IsEmpty()) return;
            buttonPanel.SetActive(false);
        }
    }
}