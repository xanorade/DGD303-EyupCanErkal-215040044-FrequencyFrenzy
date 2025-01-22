using Entitas;
using UnityEngine;

public class PlayerMovementSystem : IExecuteSystem
{
    GameContext _gameContext;

    public PlayerMovementSystem(GameContext gameContext) 
    {
        _gameContext = gameContext;
    }
    public void Execute()
    {
        GameEntity[] mobilePlayers = _gameContext.GetEntities(
            GameMatcher.AllOf(GameMatcher.Player, GameMatcher.Alive, GameMatcher.Position)
                .AnyOf(GameMatcher.Speed, GameMatcher.SpeedBoost));
        
        foreach (GameEntity player in mobilePlayers)
        {
            Vector3 oldPlayerPosition = player.position.Value;
            Vector3 PlayerSpeed = player.speed.Value;
            
            Vector3 newPlayerPosition = oldPlayerPosition + PlayerSpeed * Time.deltaTime;
            
            player.ReplacePosition(newPlayerPosition);
            
            if (player.hasSpeedBoost)
            {
                if (player.speedBoost.Duration > 0)
                {
                    player.speedBoost.Duration -= Time.deltaTime;
                    
                    if (!player.speedBoost.SpeedBoostApplied)
                    {
                        player.speedBoost.SpeedBoostApplied = true;
                        player.speed.Value *= 1 + player.speedBoost.Value;
                        Debug.Log("hizlandi");
                    }
                }
                else
                {
                    if (player.speedBoost.SpeedBoostApplied)
                    {
                        player.speedBoost.SpeedBoostApplied = false;
                        Debug.Log("yeni");
                    }
                    player.RemoveSpeedBoost();
                    player.ReplaceSpeed(new Vector3(5f,0f,0f));
                    Debug.Log("ayni hiza donduk");
                }
            }
        }
    }
}