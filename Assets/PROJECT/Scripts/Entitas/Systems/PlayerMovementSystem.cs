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
            GameMatcher.AllOf(GameMatcher.Player, GameMatcher.Alive, GameMatcher.Position)
                .AnyOf(GameMatcher.Speed, GameMatcher.SpeedBoost));
        
        foreach (GameEntity entity in entities)
        {
            Vector3 oldPlayerPosition = entity.position.Value;
            Vector3 PlayerSpeed = entity.speed.Value;
            
            Vector3 newPlayerPosition = oldPlayerPosition + PlayerSpeed * Time.deltaTime;
            
            entity.ReplacePosition(newPlayerPosition);
            
            if (entity.hasSpeedBoost)
            {
                if (entity.speedBoost.Duration > 0)
                {
                    entity.speedBoost.Duration -= Time.deltaTime;
                    
                    if (!entity.speedBoost.SpeedBoostApplied)
                    {
                        entity.speedBoost.SpeedBoostApplied = true;
                        entity.speed.Value *= 1 + entity.speedBoost.Value;
                        Debug.Log("hizlandi");
                    }
                }
                else
                {
                    // SpeedBoost süresi bittiğinde hızı eski haline getir
                    if (entity.speedBoost.SpeedBoostApplied)
                    {
                        entity.isSpeedBoostApplied = false;
                        
                    }
                    entity.RemoveSpeedBoost();
                    entity.ReplaceSpeed(new Vector3(5f,0f,0f));
                    Debug.Log("ayni hiza donduk");
                }
            }

            
            
        }
    }
}
