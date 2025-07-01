using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItemBonusSpawner : Spawner
{
     protected static UIItemBonusSpawner instance;
    public static UIItemBonusSpawner Instance => instance;
    [SerializeField] protected Transform bonusHolder;
    public Transform BonusHolder => bonusHolder;
   

 
    public static string UIItemBonus = "UIItemBonus";
   
    protected override void Awake()
    {
        base.Awake();
        if (instance != this && instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    protected override void LoadComponents()
    {
        LoadBonusHoder();
        base.LoadComponents();
      
       
    }
   
    protected virtual void LoadBonusHoder()
    {
        if (bonusHolder != null) return;
        bonusHolder = transform.parent.Find("RewardsBonus");
    }

    protected override void LoadHolder()
    {
        if (holder != null) return;
        holder = bonusHolder;
    }
   
     public virtual void SpawnItemBonus(ItemReward itemReward)
    {
        Transform item = Spawn(UIItemBonus,transform.position,Quaternion.identity);
        item.localScale = new Vector3(1, 1, 1);
        UIItem uIItem = item.GetComponent<UIItem>();
        uIItem.SetImage(itemReward.rewardSO.sprite);
        uIItem.SetText(itemReward.count);
    }
}
