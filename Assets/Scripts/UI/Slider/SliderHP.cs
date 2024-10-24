using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderHP : BaseSlider
{
    [SerializeField] protected float hp;
    [SerializeField] protected float maxHp;
    protected override void OnChanged(float newValue)
    {
       
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.HPShowing();
      
    }
    protected virtual void HPShowing()
    {
        float hpPercent = hp / maxHp;
        slider.value = hpPercent;

    }
}
