using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextValue : BaseMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI text;
    [SerializeField] protected FXDespawn despawn;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadText();
        this.LoadDespawn();
    }
    protected virtual void LoadDespawn()
    {
        if (despawn != null) return;
        despawn = transform.GetComponentInChildren<FXDespawn>();
    }
    protected virtual void LoadText()
    {
        if (this.text != null) return;
        this.text = GetComponentInChildren<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + ": LoadText", gameObject);
    }

    public virtual void SetValue(string str)
    {
        this.text.text = str;
    }
    public void FadeOut()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        float time = 0f;
        Color startColor = text.color;

        Color color = text.color;
        while (time < despawn.DelayTime)
        {
            time += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, time / despawn.DelayTime);
            text.color = color;
            yield return null;
        }
        text.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
    }
    
}
