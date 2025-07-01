using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnAddMaxGold : BaseButton
{
    protected override void OnClick()
    {
        CurrencyManager.Instance.AddGold(CurrencyManager.MaxGold);
    }

  
}
