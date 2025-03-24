using System.Collections.Generic;
using InventoryProject.UI;
using UnityEngine;
using UIType = InventoryProject.Util.Define.UIType;
using Path = InventoryProject.Util.Define.Path;

namespace InventoryProject.Managers
{
    public class UIManager : Singleton<UIManager>
    {
        private List<Transform> parents;
        private List<UIBase> uiList = new();

        public void Init(List<Transform> uiParents)
        {
            parents = uiParents;
            uiList.Clear();
        }

        public T InitUI<T>(params object[] param) where T : UIBase
        {
            var ui = uiList.Find(obj => obj.name == typeof(T).Name);
            if (ui == null)
            {
                var prefab = ResourceManager.Instance.Load<T>($"{Path.UI}{typeof(T).Name}");
                ui = Instantiate(prefab, parents[(int)prefab.UIType]);
                ui.name = typeof(T).Name;
                uiList.Add(ui);
            }

            ui.Init(param);
            return ui as T;
        }

        public void ShowUI<T>() where T : UIBase
        {
            var ui = uiList.Find(obj => obj.name == typeof(T).Name);
            if (ui == null)
            {
                var prefab = ResourceManager.Instance.Load<T>($"{Path.UI}{typeof(T).Name}");
                ui = Instantiate(prefab, parents[(int)prefab.UIType]);
                ui.name = typeof(T).Name;
                uiList.Add(ui);
            }

            if (ui.UIType == UIType.UI)
            {
                uiList.ForEach(obj =>
                {
                    if (obj.UIType == UIType.UI)
                    {
                        obj.Hide();
                    }
                });
            }

            ui.Show();
        }

        // 팝업용인건가..?
        public void HideUI<T>() where T : UIBase
        {
            var ui = uiList.Find(obj => obj.name == typeof(T).Name);
            if (ui == null) return;

            uiList.Remove(ui);
            if (ui.UIType == UIType.UI)
            {
                var prevUI = uiList.FindLast(obj => obj.UIType == UIType.UI);
                prevUI.Show();
            }

            Destroy(ui.gameObject);
        }

        public T GetUI<T>() where T : UIBase
        {
            return uiList.Find(obj => obj.name == typeof(T).Name) as T;
        }
    }
}