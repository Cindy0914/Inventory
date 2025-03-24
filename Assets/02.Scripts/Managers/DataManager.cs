using System.Collections;
using System.Collections.Generic;
using InventoryProject.Data;
using InventoryProject.Managers;
using InventoryProject.Util;
using UnityEngine;

namespace InventoryProject.Managers
{
    public class DataManager : Singleton<DataManager>
    {
        private Dictionary<int, ItemData> itemDatas = new();
        private Dictionary<string, Material> materialDatas = new();

        public void Init()
        {
            LoadItemData();
            LoadMaterialData();
        }
        
        private void LoadItemData()
        {
            var itemData = Resources.LoadAll<ItemData>(Define.Path.SO_Item);
            foreach (var data in itemData)
            {
                itemDatas.Add(data.Id, data);
            }
        }

        private void LoadMaterialData()
        {
            var materialData = Resources.LoadAll<Material>(Define.Path.Material);
            foreach (var data in materialData)
            {
                materialDatas.Add(data.name, data);
            }
        }
        
        public ItemData GetItemData(int id)
        {
            if (itemDatas.TryGetValue(id, out var value))
            {
                return value;
            }

            Debug.LogError($"DataManager : Not found item data at id: {id}");
            return null;
        }
        
        public Material GetMaterialData(string name)
        {
            if (materialDatas.TryGetValue(name, out var value))
            {
                return value;
            }

            Debug.LogError($"DataManager : Not found material data at name: {name}");
            return null;
        }
    }
}