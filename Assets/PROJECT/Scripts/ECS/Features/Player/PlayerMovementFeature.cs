    public class PlayerMovementFeature : Feature
    {
        GameContext _gameContext;

        public PlayerMovementFeature(Contexts contexts)
        {
            _gameContext = contexts.game;
            
            Add(new PlayerMovementSystem(contexts));
        }
    }
