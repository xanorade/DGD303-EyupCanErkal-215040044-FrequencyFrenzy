using System.Collections.Generic;
using Entitas;

public class TowerCountingSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _gameContext;
    private readonly int _numberOfTowers;
    
    public TowerCountingSystem(Contexts contexts) : base(contexts.game)
    {
        _gameContext = contexts.game;
        _numberOfTowers = ReferenceCatalog.Instance.towerReferences.Length;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.TowerDestroyed.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isTowerDestroyed;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        int destroyedTowerCount = _gameContext.GetEntities(GameMatcher.TowerDestroyed).Length;

        if (destroyedTowerCount >= _numberOfTowers && !_gameContext.isAllTowersDestroyed)
        {
            _gameContext.isAllTowersDestroyed = true;
        }
    }
}