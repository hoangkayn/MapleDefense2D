using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnPause : BaseButton
{
    protected override void OnClick()
    {
        GameStateManager.Instance.TogglePause();
    }
}
