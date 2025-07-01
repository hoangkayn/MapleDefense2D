using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItemSpawner : Spawner
{
    protected static UIItemSpawner instance;
    public static UIItemSpawner Instance => instance;
    [SerializeField] protected Transform rewards;

    public Transform Rewards => rewards;
    public static string UIItem = "UIItem";
   
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
        LoadRewards();
        base.LoadComponents();
       
       
    }
    protected virtual void LoadRewards()
    {
        if (rewards != null) return;
        rewards = transform.parent.Find("Rewards");
    }
   

    protected override void LoadHolder()
    {
        if (holder != null) return;
        holder = rewards;
    }
    public virtual void SpawnItemStar(ItemReward itemReward)
    {
        Transform item = Spawn(UIItem, transform.position, Quaternion.identity);
        item.localScale = new Vector3(1, 1, 1);
        UIItem uIItem = item.GetComponent<UIItem>();
        uIItem.SetImage(itemReward.rewardSO.sprite);
        uIItem.SetText(itemReward.count);
    }
   
}
