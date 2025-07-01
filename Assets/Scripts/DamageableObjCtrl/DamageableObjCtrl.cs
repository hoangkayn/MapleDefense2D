using UnityEngine;

public abstract class DamageableObjCtrl : BaseMonoBehaviour
{
    [SerializeField] protected ObjDetection objDetection;
    public ObjDetection ObjDetection => objDetection;
    [SerializeField] protected DamageableObjSO damageableObjSO;
    public DamageableObjSO DamageableObjSO => damageableObjSO;
    [SerializeField] protected Transform model;
    public Transform Model => model;
   
    [SerializeField] protected Rigidbody2D rb;
    public Rigidbody2D Rb => rb;
    [SerializeField] protected DamageReceive damageReceive;
    public DamageReceive DamageReceive => damageReceive;

   
   
    [SerializeField] protected Animator anim;
    public Animator Anim => anim;
    [SerializeField] protected ObjMovement objMovement;
    public ObjMovement ObjMovement => objMovement;


    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadObjDetection();

        this.LoadDamageableObjSO();
        this.LoadModel();
        this.LoadAnim();
      
        this.LoadRb();
        this.LoadDamageReceive();
        this.LoadObjMove();
    }
    protected virtual void LoadObjMove()
    {
        if (objMovement != null) return;
        objMovement = transform.GetComponentInChildren<ObjMovement>();
    }
    
    protected virtual void LoadDamageReceive()
    {
        if (damageReceive != null) return;
        damageReceive = transform.GetComponentInChildren<DamageReceive>();
    }
      protected virtual void LoadAnim()
    {
        if (anim != null) return;
        anim = transform.GetComponentInChildren<Animator>();
    }
    protected virtual void LoadDamageableObjSO()
    {
        if (damageableObjSO != null) return;

        string resPath = "SO/DamageableObj/" + this.GetTypeObj() + "/" + transform.name;
        this.damageableObjSO = Resources.Load<DamageableObjSO>(resPath);
    }
    protected virtual void LoadRb()
    {
        if (this.rb != null) return;
        rb = transform.GetComponent<Rigidbody2D>();
    }
    protected abstract string GetTypeObj();
    protected virtual void LoadModel()
    {
        if (model != null) return;
        this.model = transform.Find("Model");
    }
    protected virtual void LoadObjDetection()
    {
        if (objDetection != null) return;
        objDetection = transform.GetComponentInChildren<ObjDetection>();
    }
}

