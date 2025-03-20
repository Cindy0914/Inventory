using System.Collections;
using System.Collections.Generic;
using InventoryProject.Data;
using TMPro;
using UnityEngine;

namespace InventoryProject.UI
{
    public class PlayerInfo : UIBase
    {
        [Header("Character")]
        public TextMeshProUGUI CharacterName;
        public TextMeshProUGUI Level;
        public TextMeshProUGUI CurrentExp;
        
        [Header("ClassData")]
        public TextMeshProUGUI ClassName;
        public TextMeshProUGUI ExpText;
        public TextMeshProUGUI Description;

        public override void Init(params object[] param)
        {
            CharacterName.text = param[0].ToString();
            Level.text = param[1].ToString();
            CurrentExp.text = param[2].ToString();

            var classData = param[3] as ClassData;
            if (classData == null)
            {
                Debug.LogError("ClassData is null");
                return;
            }
            
            ClassName.text = classData.className;
            ExpText.text = $"{CurrentExp}/{classData.maxExp}";
            Description.text = classData.desc;
        }
        
        // TODO: Exp 등 Set함수를 만들 애들은 Init에서 안해도 되지 않을까?
    }
}
