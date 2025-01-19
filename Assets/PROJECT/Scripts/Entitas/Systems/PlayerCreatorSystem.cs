using Entitas;
using UnityEngine;

public class PlayerCreatorSystem : IInitializeSystem {
    private GameContext _context;

    public PlayerCreatorSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Initialize() {
        var player = _context.CreateEntity();
        player.isPlayer = true;
        player.isPlayerAlive = true;
        player.AddPlayerPosition(new Vector3(10, 10, 0));
        player.AddPlayerHealth(100);
        player.AddPlayerSpeed(new Vector3(5f, 0f, 0f));
        
    }
}