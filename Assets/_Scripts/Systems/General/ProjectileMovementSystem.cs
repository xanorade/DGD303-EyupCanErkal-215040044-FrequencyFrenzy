using Entitas;
using UnityEngine;

public class ProjectileMovementSystem : IExecuteSystem

{
    private readonly GameContext _gameContext;

    public ProjectileMovementSystem(GameContext gameContext)
    {
        _gameContext = gameContext;
    }

    public void Execute()
    {
        GameEntity[] entities = _gameContext.GetEntities(GameMatcher.AllOf(GameMatcher.Projectile,GameMatcher.Position));
        
        foreach (GameEntity entity in entities)
        {
            float speed = entity.projectile.Speed;
            
            Vector3 currentPosition = entity.position.Value;
            
            currentPosition += Vector3.forward * speed * Time.deltaTime; 
            
            entity.ReplacePosition(currentPosition);
            
        }
    }
}