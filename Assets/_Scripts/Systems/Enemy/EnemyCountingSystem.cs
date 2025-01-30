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
        // "EnemyDestroyed" component'inin eklendiğini tetikliyoruz
        return context.CreateCollector(GameMatcher.EnemyDeathCounter.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        Debug.Log("We found");
        int destroyedEnemyCount = _gameContext.enemyDeathCounter.KilledEnemiesCount;

        Debug.Log($"Destroyed Enemies: {destroyedEnemyCount}");

        // Eğer tüm düşmanlar öldürülmüşse, AllEnemiesDestroyed component'ini true yap.
        if (destroyedEnemyCount >= TotalEnemies && !_gameContext.isAllEnemiesDestroyed)
        {
            _gameContext.isAllEnemiesDestroyed = true;
            Debug.Log("All enemies killed!");
        }
    }
}