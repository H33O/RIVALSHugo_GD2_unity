using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject _BonusSpeed;
    [SerializeField] private float _spawnInterval = 3f;
    
    [Header("Spawn Area (Rectangle)")]
    [SerializeField] private float _spawnAreaWidth = 64f;
    [SerializeField] private float _spawnAreaHeight = 42f;
    [SerializeField] private Vector3 _spawnOffset = Vector3.zero;
    
    private float _nextSpawnTime;

    private void Start()
    {
        _nextSpawnTime = Time.time + _spawnInterval;
    }

    private void Update()
    {
        if (Time.time >= _nextSpawnTime)
        {
            SpawnEnemy();
            _nextSpawnTime = Time.time + _spawnInterval;
        }
    }

    private void SpawnEnemy()
    {
        float randomX = Random.Range(-_spawnAreaWidth / 2f, _spawnAreaWidth / 2f);
        float randomZ = Random.Range(-_spawnAreaHeight / 2f, _spawnAreaHeight / 2f);
        
        Vector3 spawnPosition = transform.position + new Vector3(randomX, 0f, randomZ) + _spawnOffset;
        
        GameObject enemy = Instantiate(_BonusSpeed, spawnPosition, transform.rotation * Quaternion.Euler(0, 180, 0));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector3 center = transform.position + _spawnOffset;
        
        Vector3 topLeft = center + new Vector3(-_spawnAreaWidth / 2f, 0, _spawnAreaHeight / 2f);
        Vector3 topRight = center + new Vector3(_spawnAreaWidth / 2f, 0, _spawnAreaHeight / 2f);
        Vector3 bottomLeft = center + new Vector3(-_spawnAreaWidth / 2f, 0, -_spawnAreaHeight / 2f);
        Vector3 bottomRight = center + new Vector3(_spawnAreaWidth / 2f, 0, -_spawnAreaHeight / 2f);
        
        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, bottomRight);
        Gizmos.DrawLine(bottomRight, bottomLeft);
        Gizmos.DrawLine(bottomLeft, topLeft);
        
        Gizmos.DrawWireSphere(center, 0.5f);
    }
}