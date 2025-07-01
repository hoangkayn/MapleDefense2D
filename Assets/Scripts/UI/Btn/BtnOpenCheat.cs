using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnOpenCheat : BaseButton
{
    [SerializeField] protected GameObject cheatObj;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCheatObj();
    }
    protected virtual void LoadCheatObj()
    {
        if (cheatObj != null) return;
        cheatObj = transform.parent.parent.parent.Find("UICenter/PanelCheat").gameObject;
    }
    protected override void OnClick()
    {
        cheatObj.SetActive(true);
    }
}
