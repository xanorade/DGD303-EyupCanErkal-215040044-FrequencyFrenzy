using Entitas;
using UnityEngine;

public class GameRunningInitializeSystem : IInitializeSystem
{
    private readonly GameStateContext _gameStateContext;

    public GameRunningInitializeSystem(GameStateContext gameStateContext)
    {
        _gameStateContext = gameStateContext;
    }

    public void Initialize()
    {
        Debug.Log("Game Running Initial State");
        if (_gameStateContext.GetEntities(GameStateMatcher.GameRunning).Length > 0) 
            return;
        
        _gameStateContext.ReplaceGameRunning(0);  
        Debug.Log("Game Running Initial false");
    }
}