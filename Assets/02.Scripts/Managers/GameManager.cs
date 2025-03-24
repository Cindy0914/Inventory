using InventoryProject.Character;
using InventoryProject.UI;
using InventoryProject.Util;
using UnityEngine;

namespace InventoryProject.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        public Player Player { get; private set; }
        private Vector2 spawnPos = new Vector3(-1f, -4.1f);

        private void Start()
        {
            DataManager.Instance.Init();
            
            SpawnPlayer();
            CreateCanvas();

            var inventory = UIManager.Instance.GetUI<Inventory>();
            for (int i = 2000; i <= 2004; i++)
            {
                var item = DataManager.Instance.GetItemData(i);
                inventory.AddItem(item);
            }
        }

        private void SpawnPlayer()
        {
            var obj = ResourceManager.Instance.Load<Player>(Define.Path.Player);
            Player = Instantiate(obj, spawnPos, Quaternion.identity);
            Player.Init();
        }

        private void CreateCanvas()
        {
            var obj = ResourceManager.Instance.Load<MainCanvas>($"{Define.Path.UI}MainCanvas");
            var canvas = Instantiate(obj);
            canvas.Init(Player);
        }
    }
}