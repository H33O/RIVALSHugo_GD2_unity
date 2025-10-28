using System.Collections;
using UnityEngine;

public class ZoneSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject _warningPrefab;
    [SerializeField] private GameObject _zoneKillPrefab;
    [SerializeField] private float _spawnInterval = 3f;
    [SerializeField] private float _warningDuration = 1f;
    
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
            StartCoroutine(SpawnZoneKillWithWarning());
            _nextSpawnTime = Time.time + _spawnInterval;
        }
    }

    private IEnumerator SpawnZoneKillWithWarning()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        
        GameObject warning = null;
        if (_warningPrefab != null)
        {
            warning = Instantiate(_warningPrefab, spawnPosition, Quaternion.identity);
        }
        
        yield return new WaitForSeconds(_warningDuration);
        
        if (warning != null)
        {
            Destroy(warning);
        }
        
        if (_zoneKillPrefab != null)
        {
            Instantiate(_zoneKillPrefab, spawnPosition, transform.rotation * Quaternion.Euler(0, 180, 0));
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float randomX = Random.Range(-_spawnAreaWidth / 2f, _spawnAreaWidth / 2f);
        float randomZ = Random.Range(-_spawnAreaHeight / 2f, _spawnAreaHeight / 2f);
        
        return transform.position + new Vector3(randomX, 0f, randomZ) + _spawnOffset;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
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
