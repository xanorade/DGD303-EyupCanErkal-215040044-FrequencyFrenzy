using Entitas;
using UnityEngine;

public class PlayerMovementSystem : IExecuteSystem
{
    GameContext _gameContext;
    InputContext _inputContext;

    public PlayerMovementSystem(GameContext gameContext, InputContext inputContext) 
    {
        _gameContext = gameContext;
        _inputContext = inputContext;
        
    }
    public void Execute()
    {
        if (_gameContext.playerEntity == null) return;
        GameEntity player = _gameContext.playerEntity;
        
        if(player.isAlive == false) return;
        if(!player.hasPosition) return;

        if (player.hasSpeedBoost)
        {
            if (player.speedBoost.Duration > 0)
            {
                if (!player.speedBoost.SpeedBoostApplied)
                {
                    player.speedBoost.SpeedBoostApplied = true;
                    player.speed.Value *= 1 + player.speedBoost.Value;
                    Debug.Log("hizlandi");
                }
                player.speedBoost.Duration -= Time.deltaTime;
            }
            else
            {
                if (player.speedBoost.SpeedBoostApplied)
                {
                    player.speedBoost.SpeedBoostApplied = false;
                    Debug.Log("bitti");
                }
                player.RemoveSpeedBoost();
                player.ReplaceSpeed(5f);
                Debug.Log("ayni hiza donduk"); }
        }
        
        Vector2 input = _inputContext.playerInput.Value;
        Vector3 displacement = new Vector3(input.x, 0, input.y) * (player.speed.Value * Time.deltaTime);
        Vector3 newPosition = player.position.Value + displacement;
        
        player.ReplacePosition(newPosition);
    }
}