using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class EnemyCountingSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _gameContext;
    private const int TotalEnemies = 10;

    public EnemyCountingSystem(Contexts contexts) : base(contexts.game)
    {
        _gameContext = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.EnemyDestroyed.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        int destroyedEnemyCount = _gameContext.GetEntities(GameMatcher.EnemyDestroyed).Length;
        

        if (destroyedEnemyCount >= TotalEnemies && !_gameContext.isAllEnemiesDestroyed)
        {
            Debug.Log("All enemies killed");
            _gameContext.isAllEnemiesDestroyed = true;
        }
    }
}