using Entitas;
using UnityEngine;

public class PlayerCreatorSystem : IInitializeSystem 
{
    private GameContext _gameContext;

    public PlayerCreatorSystem(GameContext gameContext)
    {
        _gameContext = gameContext;
    }

    public void Initialize() {
        var player = _gameContext.CreateEntity();
        player.isPlayer = true;
        player.isAlive = true;
        player.AddPosition(new Vector3(10, 10, 0));
        player.AddHealth(100);
        player.AddSpeed(new Vector3(5f, 0f, 0f));
    }
}