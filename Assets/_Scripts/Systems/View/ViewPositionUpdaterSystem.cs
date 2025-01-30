using System.Collections.Generic;
using Entitas;

public class ViewPositionUpdaterSystem : ReactiveSystem<GameEntity>
{
    private GameContext _gameContext;

    public ViewPositionUpdaterSystem(Contexts contexts) : base(contexts.game)
    {
        _gameContext = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Position);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity entity in entities)
        {
            entity.view.Value.transform.position = entity.position.Value;
        }
    }
}