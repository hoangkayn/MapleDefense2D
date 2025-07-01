using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
  
   [SerializeField] protected List<UIMenu> menuList;
    [SerializeField] protected List<CanvasGroup> canvasGroups;
    public List<CanvasGroup> CanvasGroups => canvasGroups;
   public List<UIMenu> MenuList => menuList;

   [SerializeField] protected Transform defeatUI;
    public Transform DefeatUI => defeatUI;

    [SerializeField] protected Transform resUI;
    public Transform ResUI => resUI;




    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMenuList();
        this.LoadCanvasGroups();
        this.LoadDefeatUI();
        this.LoadResUI();
      
    }
    protected virtual void LoadCanvasGroups()
    {
        if (canvasGroups.Count > 0) return;
        CanvasGroup[] array = transform.GetComponentsInChildren<CanvasGroup>();
        canvasGroups.AddRange(array);
    }
     protected virtual void LoadResUI() {
        if (resUI != null) return;
        resUI = GameObject.Find("UICenter").transform.Find("UIResult");
    }

    protected virtual void LoadDefeatUI()
    {
        if (defeatUI != null) return;
        defeatUI = GameObject.Find("UICenter").transform.Find("UIDefeat");
    }
     
    protected override void Start()
    {
        base.Start();
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChange;
        GameStateManager.Instance.OnGameStateChanged += ToggleCanvasGroups;
    }
    public virtual void ToggleCanvasGroups(eStateGame eStateGame)
    {

        if (eStateGame == eStateGame.PLAYING)
        {
            UnLockCanvasGroups();
        }
        else if(eStateGame == eStateGame.PAUSE)
        {
            LockCanvasGroups();
        }
    }
    protected virtual void LockCanvasGroups()
    {
        Time.timeScale = 0;
        foreach (CanvasGroup canvas in canvasGroups)
        {
            canvas.blocksRaycasts = false;
        }
    }
     protected virtual void UnLockCanvasGroups()
    {
         Time.timeScale = 1;
        foreach (CanvasGroup canvas in canvasGroups)
        {
          
            canvas.blocksRaycasts = true;
        }
    }
    protected virtual void LoadMenuList()
    {
        if (menuList.Count > 0) return;
        UIMenu[] array = transform.GetComponentsInChildren<UIMenu>(true);
        menuList.AddRange(array);
    }
    protected virtual void ShowMenu<T>() where T : UIMenu{
       
        foreach(UIMenu uIMenu in menuList){
            if(uIMenu is T){
                uIMenu.Show();
            }
            else{
                uIMenu.Hide();
            }
        }
    }
     public virtual void OnGameStateChange(eStateGame state)
    {
       
        switch (state)
        {
            case eStateGame.WIN:
                ShowMenu<UIResult>();
                GameStateManager.Instance.PauseGame();
                break;
            case eStateGame.LOSE:

                ShowMenu<UIDefeat>();
                  GameStateManager.Instance.PauseGame();
                break;
        }
    }
}
