using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnUpLv : BaseButton
{
   
  
    protected override void OnClick()
    {
        LevelByCoin.Instance.LevelUp();
    }
}
