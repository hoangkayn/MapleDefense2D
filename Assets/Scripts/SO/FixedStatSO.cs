using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "FixedStat", menuName = "SO/FixedStat")]
public class FixedStatSO : DamageableObjSO
{
      public int maxHp;
   
    public int dame;
    public int dameSkill;
    public int maxMp;
    

    public virtual int GetDame()
    {
        return dame;
    }

    public virtual int GetDameSkill()
    {
        return dameSkill;
    }

    public virtual int GetMaxHp()
    {
        return maxHp;
    }
}
