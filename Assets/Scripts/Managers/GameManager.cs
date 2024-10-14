using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour // Singleton
{
    public static GameManager instance;

    private GameState _currentState;
    private bool _isInputActive = true;

    public enum GameState
    {
        GameStart,
        GameOver,
        GameEnd
    }

    public bool IsInputActive()
    {
        return _isInputActive;
    }

    public void ChangeState(GameState state)
    {
        _currentState = state;

        switch (_currentState)
        {
            case GameState.GameStart:
                GameStart();
                break;
            case GameState.GameOver:
                GameOver();
                break;
            case GameState.GameEnd:
                EndGame();
                break;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        // Go to the first state
        ChangeState(GameState.GameStart);
    }

    private void GameStart()
    {
        _isInputActive = true;
    }

    private void GameOver()
    {

    }

    private void EndGame()
    {

    }
}
