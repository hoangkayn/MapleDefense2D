using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnExitSetting : BaseButton
{
    [SerializeField] protected Transform uISetting;
    protected override void OnClick()
    {
        uISetting.gameObject.SetActive(false);
    }
}
