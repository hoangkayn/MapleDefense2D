using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderMP : BaseSlider
{

    [SerializeField] private float mp;
    public float Mp => mp;
    [SerializeField] private float maxMp;
    public float MaxMp => maxMp;

    protected virtual void FixedUpdate()
    {
        this.MPShowing();
    }
    protected override void OnValueChanged(float value)
    {
        // Debug.Log("value:" + value);
    }
    protected virtual void MPShowing()
    {
        float hpPercent = mp / maxMp;
        slider.value = hpPercent;
    }
    public virtual void SetMP(int value)
    {
        this.mp = value;
    }
    public virtual void SetMaxMP(int value)
    {
        this.maxMp = value;
    }

}
