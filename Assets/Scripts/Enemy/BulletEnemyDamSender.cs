using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyDamSender : BulletDamageSender
{
    protected override string GetNameText()
    {
        return FXSpawner.TextDamageEnemy; 
    }
}
