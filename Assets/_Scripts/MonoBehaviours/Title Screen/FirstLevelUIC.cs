using UnityEngine;

public class FirstLevelUIC : MonoBehaviour
{
    private GameContext _gameContext;

    private void Awake()
    {
        _gameContext = Contexts.sharedInstance.game;
    }

    public void StartButtonClicked()
    {
        GameEntity player = _gameContext.playerEntity;
        player.isAlive = true;
    }
}