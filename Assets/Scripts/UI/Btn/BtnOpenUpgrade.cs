using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnOpenUpgrade : BaseButton
{
    [SerializeField] protected GameObject panelUpgrade;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPanelUpgrade();
    }
    protected virtual void LoadPanelUpgrade()
    {
        if (panelUpgrade != null) return;
        panelUpgrade = transform.parent.parent.Find("Panel_UpgradeHero").gameObject;
    }

    protected override void OnClick()
    {
        panelUpgrade.SetActive(true);
    }
}
