using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

public class GameRunningSystem : ReactiveSystem<GameStateEntity>
{
    private readonly GameStateContext _gameStateContext;

    public GameRunningSystem(Contexts contexts) : base(contexts.gameState)
    {
        _gameStateContext = contexts.gameState;
    }
    
    protected override ICollector<GameStateEntity> GetTrigger(IContext<GameStateEntity> context)
    {
        return context.CreateCollector(GameStateMatcher.GameRunning);
    }
    
    protected override bool Filter(GameStateEntity entity)
    {
        return true;
    }
    
    protected override void Execute(List<GameStateEntity> entities)
    {
        foreach (var gameStateEntity in entities)
        {
            if (gameStateEntity.gameRunning.Value == 1)
            {
                Time.timeScale = 1f;  // Oyun aktif
            }
            else
            {
                Time.timeScale = 0f;  // Oyun duraklatılmış
            }
        }
    }
}