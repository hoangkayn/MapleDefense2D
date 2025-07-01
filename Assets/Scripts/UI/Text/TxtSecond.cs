using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtSecond : BaseText
{
      protected virtual void FixedUpdate(){
          int minutesValue = (int)TimeManager.Instance.TimeRemaining / 60;
        int secondValue = ((int)TimeManager.Instance.TimeRemaining) - minutesValue * 60;
    
       text.text = secondValue.ToString("D2");
      }
}
