using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;
using static UnityEngine.Object;

public class PlayerViewSystem : ReactiveSystem<GameEntity>
{
    private GameContext _gameContext;

    public PlayerViewSystem(Contexts contexts) : base(contexts.game)
    {
        _gameContext = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Alive);
    }

    protected override bool Filter(GameEntity player)
    {
        return player.hasPosition;
    }

    protected override void Execute(List<GameEntity> players)
    {
        foreach (GameEntity player in players)
        {
            GameObject playerObject = Instantiate(ReferenceCatalog.Instance.playerPrefab);
            playerObject.transform.position = player.position.Value;
            
            player.AddView(playerObject);
            playerObject.Link(player);
        }
    }
}
