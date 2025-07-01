using UnityEngine;
using System.Collections;

public class InputManager : BaseMonoBehaviour
{
    protected static InputManager instance;
    public static InputManager Instance => instance;
    [SerializeField] protected float horizontalInput;
    public float HorizontalInput => horizontalInput;
    
   

    protected override void Awake()
    {
        base.Awake();
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    protected virtual void Update()
    {
        this.GetHorizontalInput();
       
    }
    protected virtual void GetHorizontalInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }



}

