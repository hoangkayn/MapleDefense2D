using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSkipCutScene : BaseButton
{
    protected override void OnClick()
    {
        Debug.Log("Skip");
        GameStateManager.Instance.GameResult();
    }
}
