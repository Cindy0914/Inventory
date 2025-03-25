using InventoryProject.Character;
using InventoryProject.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventoryProject.UI
{
    public class PlayerInfo : UIBase
    {
        public TextMeshProUGUI CharacterName;
        public TextMeshProUGUI ClassName;
        public TextMeshProUGUI Level;
        public TextMeshProUGUI ExpProgress;
        public Image ExpFillImage; 
        public TextMeshProUGUI Description;

        private float maxExp;
        
        public override void Init(params object[] param)
        {
            var player = param[0] as Player;
            var classData = player.StatHandler.ClassData;
            
            CharacterName.text = player.PlayerName;
            ClassName.text = classData.ClassName;
            Description.text = classData.Desc;
            maxExp = classData.MaxExp;
            
            SetLevel(player.Level);
            SetExp(player.CurrentExp);
        }
        
        public void SetLevel(int level)
        {
            Level.text = $"Lv.{level}";
        }
        
        public void SetExp(float exp)
        {
            ExpProgress.text = $"{exp}/{maxExp}";
            ExpFillImage.fillAmount = exp / maxExp;
        }
    }
}
