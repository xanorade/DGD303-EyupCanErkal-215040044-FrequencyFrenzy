    public class PlayerMovementFeature : Feature
    {
        private readonly GameContext _gameContext;
        private readonly InputContext _inputContext;

        public PlayerMovementFeature(Contexts contexts)
        {
            _gameContext = contexts.game;
            _inputContext = contexts.input;
            Add(new PlayerMovementSystem(_gameContext, _inputContext));
        }
    }
