using Entitas;
using UnityEngine;

[Game]
public class BoundsComponent : IComponent
{
    public Vector3 BottomLeft;
    public Vector3 TopRight;
}