public class PlayerFeature : Feature
{
    GameContext _gameContext;

    public PlayerFeature(Contexts contexts)
    {
        _gameContext = contexts.game;

        Add(new PlayerCreatorSystem(contexts));
    }
}