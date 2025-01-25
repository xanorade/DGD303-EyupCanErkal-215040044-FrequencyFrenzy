using Entitas;
using Entitas.CodeGeneration.Attributes;

[Unique, Input]
public class VerticalInputComponent : IComponent
{
    public float Value;
}