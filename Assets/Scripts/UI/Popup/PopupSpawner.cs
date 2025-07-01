using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupSpawner : Spawner
{
    protected static PopupSpawner instance;
    public static PopupSpawner Instance => instance;
  
     public static string PopupError = "PopupError";

     public static string PopupSuccess = "PopupSuccess";
      public static string PopupSelected = "PopupSelected";    
    protected override void Awake()
    {
        base.Awake();
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
}
