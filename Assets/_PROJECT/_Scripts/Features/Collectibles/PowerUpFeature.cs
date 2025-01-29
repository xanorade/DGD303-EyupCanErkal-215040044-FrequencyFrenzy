public class PowerUpFeature : Feature
{
    private readonly GameContext _gameContext;

    public PowerUpFeature(Contexts contexts)
    {
        _gameContext = contexts.game;
        Add(new SpeedBoostSystem(_gameContext));
    }
}