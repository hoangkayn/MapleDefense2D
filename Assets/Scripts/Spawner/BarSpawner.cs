using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarSpawner : Spawner
{
    private static BarSpawner instance;
    public static BarSpawner Instance => instance;
    public static string HPBar = "TrackingHpBar";
    public static string MPBar = "MPBar";

   

    protected override void Awake()
    {
        base.Awake();
        if(instance != this && instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
}