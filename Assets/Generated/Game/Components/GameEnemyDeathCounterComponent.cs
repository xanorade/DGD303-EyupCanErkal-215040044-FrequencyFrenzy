//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity enemyDeathCounterEntity { get { return GetGroup(GameMatcher.EnemyDeathCounter).GetSingleEntity(); } }
    public EnemyDeathCounterComponent enemyDeathCounter { get { return enemyDeathCounterEntity.enemyDeathCounter; } }
    public bool hasEnemyDeathCounter { get { return enemyDeathCounterEntity != null; } }

    public GameEntity SetEnemyDeathCounter(int newKilledEnemiesCount) {
        if (hasEnemyDeathCounter) {
            throw new Entitas.EntitasException("Could not set EnemyDeathCounter!\n" + this + " already has an entity with EnemyDeathCounterComponent!",
                "You should check if the context already has a enemyDeathCounterEntity before setting it or use context.ReplaceEnemyDeathCounter().");
        }
        var entity = CreateEntity();
        entity.AddEnemyDeathCounter(newKilledEnemiesCount);
        return entity;
    }

    public void ReplaceEnemyDeathCounter(int newKilledEnemiesCount) {
        var entity = enemyDeathCounterEntity;
        if (entity == null) {
            entity = SetEnemyDeathCounter(newKilledEnemiesCount);
        } else {
            entity.ReplaceEnemyDeathCounter(newKilledEnemiesCount);
        }
    }

    public void RemoveEnemyDeathCounter() {
        enemyDeathCounterEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public EnemyDeathCounterComponent enemyDeathCounter { get { return (EnemyDeathCounterComponent)GetComponent(GameComponentsLookup.EnemyDeathCounter); } }
    public bool hasEnemyDeathCounter { get { return HasComponent(GameComponentsLookup.EnemyDeathCounter); } }

    public void AddEnemyDeathCounter(int newKilledEnemiesCount) {
        var index = GameComponentsLookup.EnemyDeathCounter;
        var component = (EnemyDeathCounterComponent)CreateComponent(index, typeof(EnemyDeathCounterComponent));
        component.KilledEnemiesCount = newKilledEnemiesCount;
        AddComponent(index, component);
    }

    public void ReplaceEnemyDeathCounter(int newKilledEnemiesCount) {
        var index = GameComponentsLookup.EnemyDeathCounter;
        var component = (EnemyDeathCounterComponent)CreateComponent(index, typeof(EnemyDeathCounterComponent));
        component.KilledEnemiesCount = newKilledEnemiesCount;
        ReplaceComponent(index, component);
    }

    public void RemoveEnemyDeathCounter() {
        RemoveComponent(GameComponentsLookup.EnemyDeathCounter);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherEnemyDeathCounter;

    public static Entitas.IMatcher<GameEntity> EnemyDeathCounter {
        get {
            if (_matcherEnemyDeathCounter == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.EnemyDeathCounter);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherEnemyDeathCounter = matcher;
            }

            return _matcherEnemyDeathCounter;
        }
    }
}
