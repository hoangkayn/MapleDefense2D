using System;
using System.Collections.Generic;
using UnityEngine;
public class BtnOpenSetting : BaseButton
{
    [SerializeField] protected MusicSettingUI musicSettingUI;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        if (musicSettingUI != null) return;
        musicSettingUI = FindObjectOfType<MusicSettingUI>(true);
    }
   
   
    protected override void OnClick()
    {
       musicSettingUI.gameObject.SetActive(true);
    }
   
}
