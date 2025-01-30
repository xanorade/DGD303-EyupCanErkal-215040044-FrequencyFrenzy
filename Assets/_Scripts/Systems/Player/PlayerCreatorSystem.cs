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
        
        if (_gameContext.GetEntities(GameMatcher.Player).Length > 0)
        {
            return;
        }
        
        GameEntity player = _gameContext.CreateEntity();
        player.isPlayer = true;
        player.AddPosition(Vector3.zero);
        player.AddHealth(100);
        player.AddSpeed(_playerSpeed);
        player.AddWeapon(5f, 10);

        var bottomLeft = new Vector3(-10f, 0f, -10f);
        var topRight = new Vector3(10f, 0f, 10f);
        player.AddBounds(bottomLeft, topRight);
    }
}