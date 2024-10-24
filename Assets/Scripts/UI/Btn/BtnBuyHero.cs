using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnBuyHero : BaseButton
{
    protected override void OnClick()
    {
        string nameHero = HeroSpawner.Instance.Prefabs[transform.GetSiblingIndex()].name;
    }
}
