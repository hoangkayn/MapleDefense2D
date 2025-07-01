using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnAddMaxGem : BaseButton
{
    protected override void OnClick()
    {
        CurrencyManager.Instance.AddGem(CurrencyManager.MaxGem);
    }
}
