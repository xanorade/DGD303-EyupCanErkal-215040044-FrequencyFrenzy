using Entitas;
using UnityEngine;

public class SpeedBoostSystem : IExecuteSystem
{
    GameContext _gameContext;

    public SpeedBoostSystem(GameContext gameContext) 
    {
        _gameContext = gameContext;
    }
    
    public void Execute()
    {
        GameEntity[] speedyPlayers = _gameContext.GetEntities(GameMatcher.AllOf(GameMatcher.Player,GameMatcher.Alive));
        foreach (GameEntity player in speedyPlayers)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!player.hasSpeedBoost)
                {
                    player.AddSpeedBoost(1f,5f,false);
                    Debug.Log("speeeeeeeeeeeeeeeeed");

                }
                else
                {
                    player.ReplaceSpeedBoost(1f, 5f,true);
                    Debug.Log("SPEEEEEEEEEEEEEEEEEDDDDD");
                }
            }
            
            if (Input.GetKeyDown(KeyCode.R))
            {
                player.RemoveSpeedBoost();
            }
        }
    }
}