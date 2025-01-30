using Entitas;

public class GameRunningFeature : Feature
{
    private readonly GameStateContext _gameStateContext;
    
    public GameRunningFeature(Contexts contexts)
    {
        _gameStateContext = contexts.gameState;

        Add(new GameRunningInitializeSystem(contexts.gameState));
        Add(new GameRunningSystem(contexts));
    }
}