using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : Singleton<CoinManager>

{
    [SerializeField] protected int currentCoin = 0;
    public int CurrentCoin => currentCoin;
    [SerializeField] protected float coinTimer;
    [SerializeField] protected float coinInterval = 1f;
    [SerializeField] protected int coinIncrement = 5;
    [SerializeField] protected bool autoGenerateCoin = true;
    public event Action OnCoinChanged;

    protected virtual void Update()
    {
        if (!autoGenerateCoin) return;
        coinTimer += Time.deltaTime;
        if (coinTimer < coinInterval) return;
        this.AddCoin(coinIncrement);
        coinTimer = 0;

    }

    public virtual void AddCoin(int value)
    {
        currentCoin += value;
        OnCoinChanged?.Invoke();

    }
    public virtual bool SpendCoins(int value)
    {
        if (currentCoin < value) return false;
        currentCoin -= value;
        OnCoinChanged?.Invoke();
        return true;
    }
    public void EnableCoinGeneration()
    {
        autoGenerateCoin = true;
    }
     public void DisEnableCoinGeneration()
    {
        autoGenerateCoin = false;
    }
}
