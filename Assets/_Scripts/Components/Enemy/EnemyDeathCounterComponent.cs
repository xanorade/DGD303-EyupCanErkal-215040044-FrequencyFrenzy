using Entitas;
using Entitas.CodeGeneration.Attributes;

[Unique,Game]
public class EnemyDeathCounterComponent : IComponent
{
    public int KilledEnemiesCount;
}