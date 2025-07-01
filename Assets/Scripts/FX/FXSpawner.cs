using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    protected static FXSpawner instance;
    public static FXSpawner Instance => instance;
    public static string RestoreBlood = "RestoreBlood";
    public static string Savage = "Savage";
    public static string Talisman = "Talisman";

    public static string TextDamageHero = "TextDamageHero";
    public static string TextDamageEnemy = "TextDamageEnemy";
     public static string Eff_Heal_5 = "Eff_Heal_5";
     public static string TextHealHP = "TextHealHP";
     public static string GodPunch = "GodPunch";

    
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
