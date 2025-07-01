using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnLoseGame : BaseButton
{
    protected override void OnClick()
    {
        GameStateManager.Instance.GameOver();
    }
}
