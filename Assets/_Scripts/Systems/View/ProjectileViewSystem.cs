using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;
using static UnityEngine.Object;

public class ProjectileViewSystem : ReactiveSystem<GameEntity>
{
    private GameContext _gameContext;
    
    public ProjectileViewSystem(Contexts contexts) : base(contexts.game)
    {
        _gameContext = contexts.game;
    }
        
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Projectile);
    }

    protected override bool Filter(GameEntity projectile)
    {
        return projectile.hasPosition;
    }

    protected override void Execute(List<GameEntity> projectiles)
    {
        foreach (GameEntity projectile in projectiles)
        {
            GameObject projectileObject = Instantiate(ReferenceCatalog.Instance.projectilePrefab);

            projectileObject.transform.position = projectile.position.Value;
            
            projectile.AddView(projectileObject);
            projectileObject.Link(projectile);
        }
    }
}
