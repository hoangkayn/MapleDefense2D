using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCloseCheat : BaseButton
{
    protected override void OnClick()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
