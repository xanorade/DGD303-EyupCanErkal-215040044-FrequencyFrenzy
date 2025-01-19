public class PowerUpFeature : Feature
{
    GameContext _gameContext;

    public PowerUpFeature(Contexts contexts)
    {
        _gameContext = contexts.game;

        Add(new SpeedBoostSystem(contexts));
    }
}