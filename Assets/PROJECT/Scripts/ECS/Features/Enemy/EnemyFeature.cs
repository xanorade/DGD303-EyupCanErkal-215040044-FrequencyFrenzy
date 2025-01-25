public class EnemyFeature : Feature
{
    GameContext _gameContext;
    
    public EnemyFeature(Contexts contexts)
    {
        _gameContext = contexts.game;
        Add(new EnemySpawnerSystem(_gameContext));
    }
}