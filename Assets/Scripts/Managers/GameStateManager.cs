using System.Runtime.CompilerServices;
using UnityEngine;

/// <summary>
/// Changes Gamestates
/// </summary>
/// 
public enum GameStates 
{
    Gameplay,
    Paused,
    GameOver
}

public class GameStateManager : MonoBehaviour
{
    [SerializeField] GameStates _currentState;
    [SerializeField] GameStates _previousState;


    public void SetState(GameStates newState)
    {
        _previousState = _currentState;
        _currentState = newState;

        OnGameStateChange(prevState: _previousState, newState: _currentState);
    }

    private void OnGameStateChange(GameStates prevState, GameStates newState)
    {
        switch (newState)
        {
            default:
                break;

            case GameStates.Gameplay:
                ServiceHubManager.Instance.UIManager.ShowGameplayUI();
                Time.timeScale = 1;
                break;

            case GameStates.Paused:
                ServiceHubManager.Instance.UIManager.ShowPausedUI();
                Time.timeScale = 0;
                break;

            case GameStates.GameOver:
                ServiceHubManager.Instance.UIManager.ShowGameOverUI();
                Time.timeScale = 0;
                break;

        }
    }

    public void PauseToggle()
    {
        if(_currentState == GameStates.Gameplay)
        {
            if (_currentState == GameStates.Paused) return;
            SetState(newState: GameStates.Paused);
        }
        else if(_currentState == GameStates.Paused)
        {
            if (_currentState == GameStates.Gameplay) return;
            SetState(newState: GameStates.Gameplay);
        }
    }


}

