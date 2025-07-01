using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseImg : BaseMonoBehaviour
{
     [SerializeField] protected Image image;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadImage();
    }
    protected virtual void LoadImage()
    {
        if (image != null) return;
        image = GetComponent<Image>();
    }
}
