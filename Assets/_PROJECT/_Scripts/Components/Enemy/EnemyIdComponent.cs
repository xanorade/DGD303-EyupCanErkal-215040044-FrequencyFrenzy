using Entitas;
using Entitas.CodeGeneration.Attributes;

[PrimaryEntityIndex, Game]
public class EnemyIdComponent : IComponent
{
   public int Value;
}