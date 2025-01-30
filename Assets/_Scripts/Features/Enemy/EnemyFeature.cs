public class EnemyFeature : Feature
{
    private readonly Contexts _contexts;
    
    public EnemyFeature(Contexts contexts)
    {
        _contexts = contexts;
        Add(new EnemySpawnerSystem(contexts.game));
        Add(new EnemyMovementSystem(contexts.game));
        Add(new EnemyCountingSystem(contexts));
    }
}