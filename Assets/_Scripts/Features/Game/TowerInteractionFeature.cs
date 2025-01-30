using UnityEngine;

public class TowerInteractionFeature : Feature
{
    private readonly GameContext _gameContext;
    public TowerInteractionFeature(Contexts contexts)
    {
        _gameContext = contexts.game;

        Add(new TowerInitializationSystem(_gameContext));
        Add(new TowerCountingSystem(contexts));
        Add(new WinDetectionSystem(contexts));
    }
}