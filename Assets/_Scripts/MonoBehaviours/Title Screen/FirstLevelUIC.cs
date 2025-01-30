using System.Linq;
using Entitas;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstLevelUIC : MonoBehaviour
{
    private InputContext _inputContext;
    private GameContext _gameContext;
    private GameStateContext _gameStateContext;
    public GameObject menuPanel; 
    private bool isMenuOpen = false;

    private void Awake()
    {
        _inputContext = Contexts.sharedInstance.input;   
        _gameContext = Contexts.sharedInstance.game;
        _gameStateContext = Contexts.sharedInstance.gameState;
    }

    public void StartButtonClicked()
    {
        GameEntity player = _gameContext.playerEntity;
        player.isAlive = true;
        
        GameStateEntity gameRunning = _gameStateContext.gameRunningEntity;
        gameRunning.ReplaceGameRunning(1);
        
    }

    public void BackButtonClicked()
    {
        _gameContext.GetEntities().ToList().ForEach(entity => entity.Destroy());
        _inputContext.GetEntities().ToList().ForEach(entity => entity.Destroy());
        _gameStateContext.GetEntities().ToList().ForEach(entity => entity.Destroy());
        
        FindObjectOfType<EntityLinkCleanup>().RemoveAllEntityLinks();
        
        SceneManager.LoadScene("Title Screen");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuOpen = !isMenuOpen;
            menuPanel.SetActive(isMenuOpen);
            
            GameStateEntity gameRunning = _gameStateContext.gameRunningEntity;
            if (gameRunning != null)
            {
                int newValue = gameRunning.gameRunning.Value == 1 ? 0 : 1;
                gameRunning.ReplaceGameRunning(newValue);
            }
        }
    }
}