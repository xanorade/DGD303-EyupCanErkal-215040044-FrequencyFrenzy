using Entitas;
using UnityEngine;

public class PlayerCreatorSystem : IInitializeSystem 
{
    private GameContext _gameContext;
    
    private const float _playerSpeed = 5f;

    public PlayerCreatorSystem(GameContext gameContext)
    {
        _gameContext = gameContext;
    }

    public void Initialize() {
        GameEntity player = _gameContext.CreateEntity();
        player.isPlayer = true;
        player.isAlive = true;
        player.AddPosition(Vector3.zero);
        player.AddHealth(100);
        player.AddSpeed(_playerSpeed);
    }
}