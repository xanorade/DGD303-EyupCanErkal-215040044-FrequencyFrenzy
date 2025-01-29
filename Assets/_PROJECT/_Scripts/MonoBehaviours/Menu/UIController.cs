using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject background;
    private GameContext _gameContext;

    private void Awake()
    {
        _gameContext = Contexts.sharedInstance.game;
    }

    public void StartButtonClicked()
    {
        GameEntity player = _gameContext.playerEntity;
        player.isAlive = true;
        startButton.SetActive(false);
        background.SetActive(false);
    }
}