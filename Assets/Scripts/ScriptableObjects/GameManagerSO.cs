using UnityEngine;
using ScriptableObjectArchitecture;

[CreateAssetMenu(fileName = "GameManager", menuName = "ScriptableObjects/Game Manager")]
public class GameManagerSO : ScriptableObject
{
    public GameStateSO currentState;

    [Header("Broadcasting Events")]
    public GameStateSOGameEvent gameStateChanged;

    private GameStateSO previouState;

    public void SetGameState(GameStateSO gameState)
    {
        if (currentState != null)
        {
            previouState = currentState;
        }
        currentState = gameState;
        if (gameStateChanged != null)
        {
            gameStateChanged.Raise(gameState);
        }
    }

    public void RestorePreviousState()
    {
        SetGameState(previouState);
    }
}
