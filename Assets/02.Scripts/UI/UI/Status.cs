using InventoryProject.Character;
using InventoryProject.Data;
using InventoryProject.Managers;
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
        
        private const string enhanceColor = "<color=#25BC30>+{0}</color>";
        
        public override void Init(params object[] param)
        {
            var player = param[0] as Player;
            var classData = player.PlayerClass;

            UpdateStatus(classData.BaseStats, player.EnhancedStats);
            ReturnBtn.onClick.AddListener(() => UIManager.Instance.ShowUI<MainButtons>());
        }
        
        public void UpdateStatus(Stats baseStats, Stats enhancedStats)
        {
            HpValue.text = $"{baseStats.MaxHp} {GetEnhancedStat(enhancedStats.MaxHp)}";
            AtkValue.text = $"{baseStats.Atk} {GetEnhancedStat(enhancedStats.Atk)}";
            MagAtkValue.text = $"{baseStats.MagAtk} {GetEnhancedStat(enhancedStats.MagAtk)}";
            DefValue.text = $"{baseStats.Def} {GetEnhancedStat(enhancedStats.Def)}";
        }

        private string GetEnhancedStat(float value)
        {
            return value == 0 ? string.Empty : string.Format(enhanceColor, value);
        }
    }
}