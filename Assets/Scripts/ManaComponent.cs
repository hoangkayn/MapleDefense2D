using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ManaComponent : BaseMonoBehaviour
{
    [SerializeField] protected float currentMp;
    public float CurrentMp => currentMp;

    [SerializeField] protected float maxMp;
    public float MaxMp => maxMp;

    public event Action OnManaFull;

    protected override void Start()
    {
        this.Setup();

    }
    protected override void OnEnable()
    {
        base.OnEnable();
        this.Reborn();
    }
    protected virtual void Reborn()
    {
        this.currentMp = 0;
    }
   
    public virtual void AddMana(float value)
    {
        currentMp += value;
        if (currentMp > maxMp)
        {
            currentMp = maxMp;
             OnManaFull?.Invoke();
        }
    }
    public virtual void SpendMana()
    {
        currentMp = 0; 
    }
    protected abstract void Setup();
   
    public bool HasEnoughMana()
    {
        return currentMp >= maxMp;
    }
}
