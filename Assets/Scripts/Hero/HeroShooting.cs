using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroShooting : ObjShooting
{
   protected HeroCtrl heroCtrl => (HeroCtrl)attackableObjCtrl;
    protected override int GetDameBullet()
    {
      return  heroCtrl.HeroSO.GetDame(heroCtrl.CurrentLevel);
    }
}
