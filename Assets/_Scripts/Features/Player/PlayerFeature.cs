public class PlayerFeature : Feature
{
    private readonly GameContext _gameContext;

    public PlayerFeature(Contexts contexts)
    {
        _gameContext = contexts.game;
        Add(new PlayerCreatorSystem(_gameContext));
        Add(new PlayerDestroySystem(_gameContext));
        Add(new PlayerBoundsSystem(_gameContext));
    }
}