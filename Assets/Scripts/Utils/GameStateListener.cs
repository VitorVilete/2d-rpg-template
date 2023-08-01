using ScriptableObjectArchitecture;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStateListener : MonoBehaviour
{
    [Header("Listening to Events")]
    public GameStateSOGameEvent gameStateChangedEvent;

    [Header("Enabled & Disabled Shortcuts")]
    public MonoBehaviour[] components;
    public List<GameStateSO> enabledStates;
    public List<GameStateSO> disabledStates;

    [Header("Actions")]
    public UnityEvent onMainMenuState;
    public UnityEvent onLoadingState;
    public UnityEvent onPlayingState;
    public UnityEvent onPauseState;

    private void OnEnable()
    {
        gameStateChangedEvent.AddListener(GameStateChanged);
    }

    private void OnDisable()
    {
        gameStateChangedEvent.RemoveListener(GameStateChanged);
    }

    private void GameStateChanged(GameStateSO newGameState)
    {
        InvokeShortcuts(newGameState);
        InvokeActions(newGameState);
    }

    private void InvokeShortcuts(GameStateSO newGameState)
    {
        foreach (var component in components)
        {
            if (enabledStates.Contains(newGameState))
            {
                component.enabled = true;
            }
            if (disabledStates.Contains(newGameState))
            {
                component.enabled = false;
            }
        }
    }

    private void InvokeActions(GameStateSO newGameState)
    {
        switch (newGameState.stateName)
        {
            case "MainMenu":
                if (onMainMenuState != null) onMainMenuState.Invoke();
                break;
            case "Loading":
                if (onLoadingState != null) onLoadingState.Invoke();
                break;
            case "Playing":
                if (onPlayingState != null) onPlayingState.Invoke();
                break;
            case "Pause":
                if (onPauseState != null) onPauseState.Invoke();
                break;
            default:
                break;
        }
    }

}