using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderBar : BaseSlider
{

    [SerializeField] private float value;
    public float Value => value;
    [SerializeField] private float maxValue;
    public float MaxValue => maxValue;
    protected virtual void LateUpdate()
    {
        this.Showing();
    }
    protected override void OnValueChanged(float value)
    {
        // Debug.Log("value:" + value);
    }
    protected virtual void Showing()
    {
        if (maxValue == 0) return;
        float percent = value / maxValue;
        slider.value = percent;
    }
    public virtual void SetValue(float value)
    {
       
        this.value = value;
    }
    public virtual void SetMaxValue(float value)
    {
        
        this.maxValue = value;
    }

}
