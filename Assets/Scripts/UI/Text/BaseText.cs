using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseText : BaseMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI text;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadText();
    }
    protected virtual void LoadText()
    {
        if (text != null) return;
        text = GetComponent<TextMeshProUGUI>();
    }

}
