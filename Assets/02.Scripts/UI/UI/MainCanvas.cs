using System;
using System.Collections.Generic;
using InventoryProject.Character;
using InventoryProject.Managers;
using UnityEngine;

namespace InventoryProject.UI
{
    public class MainCanvas : MonoBehaviour
    {
        [SerializeField] private List<Transform> parents;

        public void Init(Player player)
        {
            UIManager.Instance.Init(parents);
            
            InitTop(player);
            InitUI(player);
        }

        private void InitTop(Player player)
        {
            var playerInfo = UIManager.Instance.InitUI<PlayerInfo>(player);
            playerInfo.SetLevel(player.Level);
            playerInfo.SetExp(player.CurrentExp);
            UIManager.Instance.ShowUI<PlayerInfo>();
            
            UIManager.Instance.InitUI<Currency>(player.Currency);
            UIManager.Instance.ShowUI<Currency>();
        }

        private void InitUI(Player player)
        {
            UIManager.Instance.InitUI<MainButtons>();
            UIManager.Instance.InitUI<Status>(player);
            UIManager.Instance.InitUI<Inventory>(player);

            UIManager.Instance.ShowUI<MainButtons>();
        }
    }
}