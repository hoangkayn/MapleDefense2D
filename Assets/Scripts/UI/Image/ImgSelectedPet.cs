using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEditor.Animations;
using UnityEngine;

public class ImgSelectedPet : BaseImg
{
    [SerializeField] private Animator animator;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
    }
    protected virtual void LoadAnimator()
    {
        if (animator != null) return;
        animator = transform.GetComponent<Animator>();
    }
    public void Show(PetSO petSO)
    {
        animator.runtimeAnimatorController = petSO.animatorController;
    }
}
