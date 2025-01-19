using Entitas;

[Game]
public class SpeedBoostComponent : IComponent
{
    public float Value;
    public float Duration;
    public bool SpeedBoostApplied;
}