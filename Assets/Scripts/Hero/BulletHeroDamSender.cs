using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHeroDamSender : BulletDamageSender
{
     protected override string GetNameText()
    {
        return FXSpawner.TextDamageHero;
    }
}
