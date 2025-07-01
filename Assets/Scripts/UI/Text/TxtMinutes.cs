using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtMinutes : BaseText
{
    protected virtual void FixedUpdate() {
         int minutesValue = (int)TimeManager.Instance.TimeRemaining / 60;
      
        text.text = minutesValue.ToString();
      
    }
}
