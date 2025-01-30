using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;
using static UnityEngine.Object;

public class EnemyViewSystem : ReactiveSystem<GameEntity>
{
    private GameContext _gameContext;

    public EnemyViewSystem(Contexts contexts) : base(contexts.game)
    {
        _gameContext = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Enemy);
    }

    protected override bool Filter(GameEntity enemy)
    {
        return enemy.hasPosition;
    }

    protected override void Execute(List<GameEntity> enemies)
    {
        foreach (GameEntity enemy in enemies)
        {
            GameObject enemyObject = Instantiate(ReferenceCatalog.Instance.enemyPrefab);
            
            enemyObject.transform.position = enemy.position.Value;
            
            enemy.AddView(enemyObject);
            enemyObject.Link(enemy);
        }
    }
}