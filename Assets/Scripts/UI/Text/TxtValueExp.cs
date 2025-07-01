using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtValueExp : BaseText
{
    public virtual void SetText(int currentExp, int maxExp)
    {
        this.text.text = currentExp + "/" + maxExp;
  }
}
