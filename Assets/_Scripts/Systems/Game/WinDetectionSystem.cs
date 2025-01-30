using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class WinDetectionSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _gameContext;
    
    public WinDetectionSystem(Contexts contexts): base(contexts.game)
    {
        _gameContext = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllTowersDestroyed);
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        GameEntity player = _gameContext.playerEntity;
        //player.Destroy();
        ReferenceCatalog.Instance.winScreen.SetActive(true);
        
    }
}
