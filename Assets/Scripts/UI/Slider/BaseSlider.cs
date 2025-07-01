using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSlider : BaseMonoBehaviour
{
    [SerializeField] protected Slider slider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlider();
    }
    protected virtual void LoadSlider()
    {
        if (slider != null) return;
        slider = GetComponent<Slider>();
    }
    protected override void Start()
    {
        base.Start();
        this.AddOnClickEven();
    }
    protected virtual void AddOnClickEven()
    {
        slider.onValueChanged.AddListener(this.OnValueChanged);
    }
    protected abstract void OnValueChanged(float value);
}
