using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TxtCoin : BaseText
{
    protected override void Start() {
       
        CoinManager.Instance.OnCoinChanged += SetText;
        SetText();
   }
    protected virtual void SetText()
    {
        text.text = CoinManager.Instance.CurrentCoin.ToString();
    }
}
