using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObjCtrl : BaseMonoBehaviour
{
    [SerializeField] protected ObjMovement objMovement;
    public ObjMovement ObjMovement => objMovement;
    [SerializeField] protected ObjDetection objDetection;
    public ObjDetection ObjDetection => objDetection;
    [SerializeField] protected ObjMoveableSO objMoveableSO;
    public ObjMoveableSO ObjMoveableSO => objMoveableSO;
    [SerializeField] protected DamageReceive damageReceive;
    public DamageReceive DamageReceive => damageReceive;
    [SerializeField] protected Transform model;
    public Transform Model => model;
    [SerializeField] protected Animator anim;
    public Animator Anim => anim;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjMovement();
        this.LoadObjDetection();
        this.LoadObjMoveableSO();
        this.LoadDamageReceive();
        this.LoadModel();
        this.LoadAnim();
    }
    protected virtual void LoadAnim()
    {
        if (anim != null) return;
        anim = transform.GetComponentInChildren<Animator>();
    }
    protected virtual void LoadModel()
    {
        if (model != null) return;
        this.model = transform.Find("Model");
    }
    protected virtual void LoadDamageReceive()
    {
        if (damageReceive != null) return;
        this.damageReceive = transform.GetComponentInChildren<DamageReceive>();
    }
    protected virtual void LoadObjMoveableSO()
    {
        if (this.objMoveableSO != null) return;
        string resPath = "SO/ObjMoveable/" + transform.name;
        this.objMoveableSO = Resources.Load<ObjMoveableSO>(resPath);
        

    }
    protected virtual void LoadObjMovement()
    {
        if (objMovement != null) return;
        objMovement = transform.GetComponentInChildren<ObjMovement>();
    }
    protected virtual void LoadObjDetection()
    {
        if (objDetection != null) return;
        objDetection = transform.GetComponentInChildren<ObjDetection>();
    }
    
}

