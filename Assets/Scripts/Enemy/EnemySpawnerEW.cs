using UnityEngine;

public class EnemySpawnerEW : MonoBehaviour
{
    
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnInterval = 3f;
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
        float randomPosition = Random.Range(-_spawnAreaLength / 1f, _spawnAreaLength / 45f);
        Vector3 spawnPosition = transform.position + transform.right * randomPosition + _spawnOffset;
        
        GameObject enemy = Instantiate(_enemyPrefab, spawnPosition, transform.rotation * Quaternion.Euler(0, 180, 0));

    }

    
}