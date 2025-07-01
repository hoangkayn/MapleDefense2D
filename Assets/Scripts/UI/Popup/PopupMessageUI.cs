using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupMessageUI : BaseMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI text;
    [SerializeField] protected Despawn despawn;
    public Despawn Despawn => despawn;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadText();
        LoadDespawn();
    }
    protected virtual void LoadDespawn()
    {
        if (despawn != null) return;
        despawn = transform.GetComponentInChildren<Despawn>();
    }

    protected virtual void LoadText()
    {
        if (text != null) return;
        text = transform.GetComponentInChildren<TextMeshProUGUI>();
    }
    public virtual void Show(string mess)
    {
        text.text = mess;
    }
}
