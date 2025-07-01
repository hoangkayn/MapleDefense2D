using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : BaseMonoBehaviour
{
    [SerializeField] protected Image image;
    [SerializeField] protected TextMeshProUGUI text;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadImage();
        this.LoadText();
    }
    protected virtual void LoadImage()
    {
        if (image != null) return;
        image = transform.GetComponentInChildren<Image>();
       
    }
    protected virtual void LoadText()
    {
        if (text != null) return;
       
        text = transform.GetComponentInChildren<TextMeshProUGUI>();
    }
    public virtual void SetImage(Sprite sprite)
    {
        image.sprite = sprite;
    }
    public virtual void SetText(int count)
    {
        this.text.text = count.ToString();
    }
}
