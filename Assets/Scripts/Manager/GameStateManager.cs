
using System;
using System.Net.Security;
using UnityEngine;
public class GameStateManager : Singleton<GameStateManager>
{
  protected eStateGame eStateGame;

  public eStateGame EStateGame
  {
    get { return eStateGame; }
    private set
    {
      eStateGame = value;
      OnGameStateChanged?.Invoke(eStateGame);
    }

  }
  public event Action<eStateGame> OnGameStateChanged;

  protected override void Awake()
  {
    base.Awake();
    eStateGame = eStateGame.PLAYING;
  }
  public virtual void GameOver()
  {
    Debug.Log("GameOver");
    EStateGame = eStateGame.LOSE;
  }
  public virtual void GameResult()
  {
    Debug.Log("GameResult");
    EStateGame = eStateGame.WIN;
  }
  public virtual void PauseGame()
  {
     Debug.Log("PauseGame");
    EStateGame = eStateGame.PAUSE;
  }
  public virtual void ResumeGame()
  {
     Debug.Log("ResumeGame");
    EStateGame = eStateGame.PLAYING;
  }
  
  public void TogglePause()
    {
        if (EStateGame == eStateGame.PLAYING)
        {
            PauseGame();
        }
        else if (EStateGame == eStateGame.PAUSE)
        {
            ResumeGame();
        }
    }
   
}
