using Entitas;
using UnityEngine;

public class PlayerDestroySystem : ICleanupSystem
{ 
    private readonly GameContext _gameContext;

    public PlayerDestroySystem(GameContext gameContext)
    {
        _gameContext = gameContext;
    }

    public void Cleanup()
    {
        GameEntity[] deadPlayers = _gameContext.GetEntities(GameMatcher.AllOf(GameMatcher.Player).NoneOf(GameMatcher.Alive));
        
        foreach (GameEntity player in deadPlayers)
        {
            //player.Destroy();
            //Debug.Log("YOU IS DEAD");
        }
    }
}