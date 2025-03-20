using UnityEngine;
using UIType = InventoryProject.Util.Define.UIType;

namespace InventoryProject.UI
{
    public abstract class UIBase : MonoBehaviour
    {
        public UIType UIType;
        public abstract void Init(params object[] param);

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}