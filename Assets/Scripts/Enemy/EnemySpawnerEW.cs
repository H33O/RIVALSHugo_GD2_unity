using UnityEngine;

public class EnemySpawnerEW : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnInterval = 3f;
    
    [Header("Spawn Area (Line)")]
    [SerializeField] private float _spawnAreaLength = 38f;
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
        float randomPosition = Random.Range(-_spawnAreaLength / 2f, _spawnAreaLength / 2f);
        Vector3 spawnPosition = transform.position + transform.right * randomPosition + _spawnOffset;
        
        GameObject enemy = Instantiate(_enemyPrefab, spawnPosition, transform.rotation * Quaternion.Euler(0, 180, 0));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 center = transform.position + _spawnOffset;
        
        Vector3 leftPoint = center + transform.right * (-_spawnAreaLength / 2f);
        Vector3 rightPoint = center + transform.right * (_spawnAreaLength / 2f);
        
        Gizmos.DrawLine(leftPoint, rightPoint);
        
        Gizmos.DrawWireSphere(leftPoint, 0.5f);
        Gizmos.DrawWireSphere(rightPoint, 0.5f);
        Gizmos.DrawWireSphere(center, 0.3f);
    }
}
