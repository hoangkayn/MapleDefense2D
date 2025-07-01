using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnOpenShop : BaseButton
{
    [SerializeField] protected GameObject panelShop;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPanelShop();
    }
    protected virtual void LoadPanelShop()
    {
        if (panelShop != null) return;
        panelShop = transform.parent.parent.Find("Panel_ShopPet").gameObject;
    }

    protected override void OnClick()
    {
        panelShop.SetActive(true);
    }
}
