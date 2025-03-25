using InventoryProject.Character;
using InventoryProject.Data;
using InventoryProject.Managers;
using InventoryProject.Util;
using TMPro;
using UnityEngine.UI;
using StatType = InventoryProject.Util.Define.StatType;

namespace InventoryProject.UI
{
    public class Status : UIBase
    {
        public TextMeshProUGUI HpValue;
        public TextMeshProUGUI AtkValue;
        public TextMeshProUGUI MagAtkValue;
        public TextMeshProUGUI DefValue;
        public Button ReturnBtn;
        
        private const string enhanceColor = "<color=#25BC30>+{0}</color>";
        
        public override void Init(params object[] param)
        {
            var player = param[0] as Player;
            var statHandler = player.StatHandler;

            UpdateStatus(statHandler);
            ReturnBtn.onClick.AddListener(() => UIManager.Instance.ShowUI<MainButtons>());
        }
        
        public void UpdateStatus(StatHandler statHandler)
        {
            HpValue.text = $"{statHandler.GetBaseStat(StatType.MaxHp)} {GetEnhancedStat(statHandler.GetEnhancedStat(StatType.MaxHp))}";
            AtkValue.text = $"{statHandler.GetBaseStat(StatType.Atk)} {GetEnhancedStat(statHandler.GetEnhancedStat(StatType.Atk))}";
            MagAtkValue.text = $"{statHandler.GetBaseStat(StatType.MagAtk)} {GetEnhancedStat(statHandler.GetEnhancedStat(StatType.MagAtk))}";
            DefValue.text = $"{statHandler.GetBaseStat(StatType.Def)} {GetEnhancedStat(statHandler.GetEnhancedStat(StatType.Def))}";
        }

        private string GetEnhancedStat(float value)
        {
            return value == 0 ? string.Empty : string.Format(enhanceColor, value);
        }
    }
}