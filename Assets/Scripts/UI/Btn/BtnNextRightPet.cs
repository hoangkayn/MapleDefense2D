using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnNextRightPet : BaseButton
{
    [SerializeField] protected SelectPetUI selectPetUI;
    protected override void LoadButton()
    {
        base.LoadButton();
        this.LoadSelectPetUI();
    }
    protected virtual void LoadSelectPetUI()
    {
        if (selectPetUI != null) return;
        selectPetUI = transform.parent.GetComponent<SelectPetUI>();
    }
    protected override void OnClick()
    {
        selectPetUI.SelectNextPet();
    }
}
