using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnWinGame : BaseButton
{
    protected override void OnClick()
    {
        GameStateManager.Instance.GameResult();
    }
}
