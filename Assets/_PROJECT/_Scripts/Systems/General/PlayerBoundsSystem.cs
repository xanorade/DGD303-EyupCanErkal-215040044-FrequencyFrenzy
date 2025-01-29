using Entitas;
using UnityEngine;

public class PlayerBoundsSystem : IInitializeSystem, IExecuteSystem
{
    private readonly GameContext _gameContext;

    private Vector3 _bottomLeft;
    private Vector3 _topRight;
    private Plane _playerPlane;
    private Camera _cam;
    private const float Border = 0.05f;

    public PlayerBoundsSystem(GameContext gameContext)
    {
        _gameContext = gameContext;
    }

    public void Initialize()
    {
        _playerPlane = new Plane(Vector3.up, Vector3.zero);

        _cam = Camera.main;
        if (_cam == null)
        {
            Debug.LogError("Main Camera is missing!");
            return;
        }

        Vector2 screenDimensions = new Vector2(Screen.width, Screen.height);

        Ray bottomLeftRay = _cam.ScreenPointToRay(screenDimensions * Border);
        _playerPlane.Raycast(bottomLeftRay, out float bottomLeftDistance);
        _bottomLeft = bottomLeftRay.GetPoint(bottomLeftDistance);

        Ray topRightRay = _cam.ScreenPointToRay(screenDimensions * (1-Border)); 
        _playerPlane.Raycast(topRightRay, out float topRightDistance);
        _topRight = topRightRay.GetPoint(topRightDistance);

        Debug.Log($"BottomLeft: {_bottomLeft}, TopRight: {_topRight}");
    }

    public void Execute()
    {
        if (_gameContext.playerEntity == null)
        {
            Debug.Log("bound system is not working because there is no player entity.");
            return;
        }
        
        GameEntity player = _gameContext.playerEntity;

        if (!player.hasPosition)
        {
            Debug.Log("player has no position.");
            return;
        }

        Vector3 position = player.position.Value;

        float clampedX = Mathf.Clamp(position.x, _bottomLeft.x, _topRight.x);
        float clampedZ = Mathf.Clamp(position.z, _bottomLeft.z, _topRight.z);

        position = new Vector3(clampedX, position.y, clampedZ);
        player.ReplacePosition(position);
    }
}