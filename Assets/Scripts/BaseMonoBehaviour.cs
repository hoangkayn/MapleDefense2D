using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMonoBehaviour : MonoBehaviour
{
  
 protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }
    protected virtual void LoadComponents()
    {

    }
    protected virtual void Awake()
    {
        this.LoadComponents();
        this.ResetValue();
    }
    protected virtual void Start()
    {

    }
    protected virtual void OnEnable()
    {
        
    }
    protected virtual void ResetValue()
    {

    }
}
