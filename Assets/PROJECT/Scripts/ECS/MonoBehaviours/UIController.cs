using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _startButton;
    GameContext _gameContext;

    private void Awake()
    {
        _gameContext = Contexts.sharedInstance.game;
    }

    public void StartButtonClicked()
    {
        GameEntity player = _gameContext.playerEntity;
        player.isAlive = true;
        
        _startButton.SetActive(false);
    }
}
