using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnBackHome : BaseButton
{
    protected override void OnClick()
    {
        transform.parent.parent.gameObject.SetActive(false);
    }
}
