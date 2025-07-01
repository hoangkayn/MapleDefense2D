using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamSender : FixedStatDamSender
{
    protected override string GetNameText()
    {
        return FXSpawner.TextDamageEnemy;
    }
}
