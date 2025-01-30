using Entitas;
using Entitas.Unity;
using UnityEngine;

public class TowerInitializationSystem : IInitializeSystem
{
    private GameContext _gameContext;
    
    public TowerInitializationSystem(GameContext gameContext)
    { 
        _gameContext = gameContext;
    }

    public void Initialize()
    {
        ReferenceCatalog catalog = ReferenceCatalog.Instance;
        int numberOfTowers = catalog.towerReferences.Length;

        for (int i = 0; i < numberOfTowers; i++)
        {
            GameEntity tower = _gameContext.CreateEntity();
            tower.isTower = true;
            tower.AddView(catalog.towerReferences[i]);
            catalog.towerReferences[i].Link(tower);

            tower.AddTriggerOrder(i + 1);
        }
    }
}