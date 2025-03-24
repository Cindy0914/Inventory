using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace InventoryProject.UI
{
    public class Currency : UIBase
    {
        public TextMeshProUGUI Value;

        public override void Init(params object[] param)
        {
            Value.text = param[0].ToString();
        }
    }
}