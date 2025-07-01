using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtNamePlayer : BaseText
{
    protected override void Start()
    {
        base.Start();
        SetText();
    }
    protected virtual void SetText() {
        text.text = GameDataManager.Instance.Player.playerName;
    }
}
