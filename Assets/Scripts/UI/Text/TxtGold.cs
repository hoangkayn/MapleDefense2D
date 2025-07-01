using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtGold : BaseText
{
  
  protected override void OnDisable()
    {
        base.OnDisable();
        CurrencyManager.OnGoldChanged -= Refresh;
    }
    protected override void OnEnable()
    {
        base.OnEnable();
         CurrencyManager.OnGoldChanged += Refresh;
    }
     protected override void Start()
    {
        base.Start();
        Refresh(GameDataManager.Instance.Gold);
    }
    protected virtual void Refresh(int value)
    {
        this.text.text = value.ToString();
    }
}
