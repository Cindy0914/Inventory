using TMPro;
using UnityEngine.UI;

namespace InventoryProject.UI
{
    public class Status : UIBase
    {
        public TextMeshProUGUI HpValue;
        public TextMeshProUGUI AtkValue;
        public TextMeshProUGUI MagAtkValue;
        public TextMeshProUGUI DefValue;
        public Button ReturnBtn;
        
        public override void Init(params object[] param)
        {
            HpValue.text = param[0].ToString();
            AtkValue.text = param[1].ToString();
            MagAtkValue.text = param[2].ToString();
            DefValue.text = param[3].ToString();
            
            // Buttons UI 켜줘야됨
            // ReturnBtn.onClick.AddListener(UIManager.Instance.HideUI<Status>);
        }
    }
}