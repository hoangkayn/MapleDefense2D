using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageSender : BaseMonoBehaviour
{
    [SerializeField] protected float dame;

    public virtual void Send(DamageReceive damageReceive)
    {
        damageReceive.DeductHP(dame);
        this.CreatTextDamage(damageReceive.transform.position,dame);
    }
    public virtual void Send(Transform obj)
    {
        if (obj == null) return;
        DamageReceive damageReceive = obj.GetComponent<DamageReceive>();
        if (damageReceive == null) return;
        this.Send(damageReceive);
        
    }
   
    protected virtual void CreatTextDamage(Vector3 pos,float dame)
    {
        string nameText = GetNameText();
        Transform textObj = FXSpawner.Instance.Spawn(nameText, pos, Quaternion.identity);
        TextValue textDamage = textObj.GetComponent<TextValue>();
        string str = dame.ToString();
        textDamage.SetValue(str);
        textDamage.FadeOut();
    }
       protected abstract string GetNameText(); 
}
