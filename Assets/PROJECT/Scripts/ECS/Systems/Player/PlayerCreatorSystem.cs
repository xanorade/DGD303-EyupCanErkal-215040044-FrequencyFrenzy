using Entitas;
using UnityEngine;

public class PlayerCreatorSystem : IInitializeSystem 
{
    private GameContext _gameContext;
    
    private const float _playerSpeed = 10f;

    public PlayerCreatorSystem(GameContext gameContext)
    {
        _gameContext = gameContext;
    }

    public void Initialize() {
        GameEntity player = _gameContext.CreateEntity();
        player.isPlayer = true;
        //player.isAlive = true;
        player.AddPosition(Vector3.zero);
        player.AddHealth(100);
        player.AddSpeed(_playerSpeed);
        
        var bottomLeft = new Vector3(-10f, 0f, -10f);
        var topRight = new Vector3(10f, 0f, 10f);
        player.AddBounds(bottomLeft, topRight);
    }
}