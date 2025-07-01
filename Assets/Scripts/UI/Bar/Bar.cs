using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bar : BaseMonoBehaviour
{
   
    [SerializeField] protected SliderBar slider;
   
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlider();
       
    }
   
    protected virtual void Update()
    {
        this.Showing();
    }
    protected virtual void LoadSlider()
    {
        if (slider != null) return;
        slider = transform.GetComponentInChildren<SliderBar>();
    }
   

    protected abstract void Showing();
   
    
}
