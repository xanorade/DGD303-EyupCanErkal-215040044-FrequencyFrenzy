using Entitas;
using Entitas.Unity;
using UnityEngine;
using static UnityEngine.Object;

public class ProjectileShooterSystem : IExecuteSystem
{
    private readonly GameContext _gameContext;
    private float _fireCooldown = 1f;

    public ProjectileShooterSystem(GameContext gameContext)
    {
        _gameContext = gameContext;
    }

    public void Execute()
    {
        if (_gameContext.playerEntity is { hasWeapon: false })
        {
            return;
        }

        GameEntity player = _gameContext.playerEntity;

        _fireCooldown -= Time.deltaTime;

        if (_fireCooldown <= 0f)
        {   
            GameEntity projectile = _gameContext.CreateEntity();
            projectile.AddProjectile(5f); 
            projectile.AddPosition(player.position.Value + new Vector3(0f, 0f, 1f));
            
            _fireCooldown = 1f;
        }
        
    }
    
}
