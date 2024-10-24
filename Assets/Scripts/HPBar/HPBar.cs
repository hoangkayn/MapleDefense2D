using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : BaseMonoBehaviour
{
    [Header("HP Bar")]
    
    [SerializeField] protected SliderHP sliderHP;
    [SerializeField] protected FollowTarget followTarget;
    public FollowTarget FollowTarget => followTarget;

    protected virtual  void FixedUpdate()
    {
      //  this.HPShowing();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSliderHp();
        this.LoadFollowTarget();
    }

  protected virtual void LoadFollowTarget()
    {
        if (this.followTarget != null) return;
        this.followTarget = transform.GetComponent<FollowTarget>();
    }

    protected virtual void LoadSliderHp()
    {
        if (this.sliderHP != null) return;
        this.sliderHP = transform.GetComponentInChildren<SliderHP>();
      
    }

  

   /* protected virtual void HPShowing()
    {
        if (this.shootableObjectCtrl == null) return;
        bool isDead = this.shootableObjectCtrl.DamageReceiver.IsDead();
        if (isDead)
        {
            this.spawner.Despawn(transform);
            return;
        }

        float hp = this.shootableObjectCtrl.DamageReceiver.HP;
        float maxHp = this.shootableObjectCtrl.DamageReceiver.HPMax;

        this.sliderHp.SetCurrentHp(hp);
        this.sliderHp.SetMaxHp(maxHp);
   }
   */
    }



