using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class UIMenu : BaseMonoBehaviour
{
    public virtual void  Setup( ){

    }

     public virtual void  Show( ){
     
        gameObject.SetActive(true);
     }

      public virtual void  Hide( ){
 gameObject.SetActive(false);
      }
}
