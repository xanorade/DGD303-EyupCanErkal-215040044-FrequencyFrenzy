using Entitas;
using UnityEngine;

public class EnemyMovementSystem : IExecuteSystem
{
    private readonly GameContext _gameContext;

    public EnemyMovementSystem(GameContext gameContext)
    {
        _gameContext = gameContext;
    }

    public void Execute()
    {
        GameEntity[] enemies = _gameContext.GetEntities(GameMatcher.Enemy);
        
        foreach (var enemy in enemies)
        {
            if (!enemy.hasPosition || !enemy.hasSpeed) continue;

            Vector3 directionToZero = new Vector3(0,0,-100) - enemy.position.Value;
            directionToZero.y = 0f; 
            directionToZero.Normalize(); 
            
            Vector3 displacement = directionToZero * (enemy.speed.Value * Time.deltaTime);
            Vector3 newPosition = enemy.position.Value + displacement;
            enemy.ReplacePosition(newPosition);
        }
    }
}