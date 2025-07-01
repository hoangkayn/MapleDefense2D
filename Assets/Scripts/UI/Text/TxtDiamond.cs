using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtDiamond : BaseText
{
   
    protected override void OnDisable()
    {
        base.OnDisable();
        CurrencyManager.OnGemChanged -= Refresh;
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        CurrencyManager.OnGemChanged += Refresh;
      
    }
    protected override void Start()
    {
        base.Start();
        Refresh(GameDataManager.Instance.Gem);
    }
    protected virtual void Refresh(int value)
    {
        this.text.text = value.ToString();
    }
}
