using System.Collections;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class TowerDetector : MonoBehaviour
{
    private EntityLink _link;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Material _triggeredMaterial;
    
    private bool _isTriggered;
    
    private static int _currentTriggerOrder = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (_isTriggered) return;

        _link = GetComponent<EntityLink>();
        GameEntity towerEntity = _link.entity as GameEntity;

        if (towerEntity.triggerOrder.Value != _currentTriggerOrder) return;

        _isTriggered = true;
        
        HandleEntity();
        HandleMaterial();
        Debug.Log($"Detected: {towerEntity.triggerOrder.Value}");

        _currentTriggerOrder++;
    }

    private void HandleEntity()
    {
        _link = GetComponent<EntityLink>();
        GameEntity towerEntity = _link.entity as GameEntity;
        towerEntity.isTowerDestroyed = true;
    }

    private void HandleMaterial()
    {
        _meshRenderer.material = _triggeredMaterial;
        StartCoroutine(MoveDown());
    }

    private IEnumerator MoveDown()
    {
        Vector3 startPos = transform.position;
        Vector3 targetPos = new Vector3(startPos.x, -8f, startPos.z);
    
        float duration = 1f; 
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
    }
}