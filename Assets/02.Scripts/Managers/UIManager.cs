using System.Collections.Generic;
using InventoryProject.UI;
using UnityEngine;

namespace InventoryProject.Managers
{
    public class UIManager : Singleton<UIManager>
    {
        private List<Transform> parents;
        private Dictionary<string, UIBase> uiList = new();

        public void Init(List<Transform> uiParents)
        {
            parents = uiParents;
            uiList.Clear();
        }
        
        public void InitUI<T> (params object[] param) where T : UIBase
        {
            // UIBase ui = uiList.GetUI(type);
            // ui.Init();
        }
        
        public void ShowUI<T>() where T : UIBase
        {
            // UIBase ui = uiList.GetUI(type);
            // ui.Show();
        }
        
        public void HideUI<T>() where T : UIBase
        {
            // UIBase ui = uiList.GetUI(type);
            // ui.Hide();
        }
        
        public T GetUI<T>() where T : UIBase
        {
            // return uiList.GetUI(type);
            return default;
        }
    }
}
