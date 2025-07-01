using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtLvPlayer : BaseText
{

    protected override void OnEnable()
    {
        base.OnEnable();
        PlayerStats.OnLevelChanged += SetText;
    }
    protected override void Start()
    {
        base.Start();
      
        int lv = PlayerStats.Instance.PlayerSaveData.playerLevel;
       
        SetText(lv);
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        PlayerStats.OnLevelChanged -= SetText;

    }
    protected virtual void SetText(int value)
    {
        this.text.text = value.ToString();
    }
}
