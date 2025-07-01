using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderExp : BaseSlider
{
    [SerializeField] protected TxtValueExp txtValueExp;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTxtValueExp();
    }
    protected virtual void LoadTxtValueExp()
    {
        if (txtValueExp != null) return;
        txtValueExp = transform.GetComponentInChildren<TxtValueExp>();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        PlayerStats.OnExpChanged += ExpShowing;
    }
    protected override void Start()
    {
        base.Start();
        int currentExp = PlayerStats.Instance.PlayerSaveData.playerExp;
        int lv = PlayerStats.Instance.PlayerSaveData.playerLevel;
        int maxExp = PlayerStats.Instance.ExpTableSO.GetExpForLevel(lv);
        ExpShowing(currentExp, maxExp);
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        PlayerStats.OnExpChanged -= ExpShowing;

    }
    protected virtual void ExpShowing(int exp, int maxExp)
    {
        float expPercent = (float)exp / maxExp;
        slider.value = expPercent;
        txtValueExp.SetText(exp, maxExp);
    }
    protected override void OnValueChanged(float value)
    {
    }
}
