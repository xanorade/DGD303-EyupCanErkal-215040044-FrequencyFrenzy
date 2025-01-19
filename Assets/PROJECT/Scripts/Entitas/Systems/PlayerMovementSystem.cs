using Entitas;
using UnityEngine;

public class PlayerMovementSystem : IExecuteSystem
{
    GameContext _context;

    public PlayerMovementSystem(Contexts contexts) 
    {
        _context = contexts.game;
    }
    public void Execute()
    {
        //GameEntity player = _context.GetGroup(GameMatcher.Player).GetSingleEntity();
        

        GameEntity[] entities = _context.GetEntities(
            GameMatcher.AllOf(GameMatcher.Player, GameMatcher.PlayerAlive, GameMatcher.PlayerPosition)
                .AnyOf(GameMatcher.PlayerSpeed, GameMatcher.SpeedBoost));
        
        foreach (GameEntity entity in entities)
        {
            Vector3 oldPlayerPosition = entity.playerPosition.Value;
            Vector3 playerSpeed = entity.playerSpeed.Value;
            
            Vector3 newPlayerPosition = oldPlayerPosition + playerSpeed * Time.deltaTime;
            
            entity.ReplacePlayerPosition(newPlayerPosition);
            
            if (entity.hasSpeedBoost)
            {
                if (entity.speedBoost.Duration > 0)
                {
                    entity.speedBoost.Duration -= Time.deltaTime;

                    // Eğer hız boost'ı daha önce uygulanmadıysa
                    if (!entity.isSpeedBoostApplied)
                    {
                        entity.isSpeedBoostApplied = true;
                        entity.playerSpeed.Value *= 1 + entity.speedBoost.Value;  // Hızı bir kez arttır
                    }
                }
                else
                {
                    // SpeedBoost süresi bittiğinde hızı eski haline getir
                    if (entity.isSpeedBoostApplied)
                    {
                        entity.isSpeedBoostApplied = false;  // Flag'i sıfırlayın
                        entity.playerSpeed.Value /= 1 + entity.speedBoost.Value; // Hızı eski haline getir
                    }

                    entity.RemoveSpeedBoost();
                }
            }

            
            
        }
    }
}
