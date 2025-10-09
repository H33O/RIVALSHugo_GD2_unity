using System;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using Random = UnityEngine.Random;

public class WallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private Index[] _spawnPoints;
    private void OnEnable()
    {
        Player_Collect.onTargetCollected +=SpawnNewWall ;
    }

    private void OnDisable()
    {
        Player_Collect.onTargetCollected +=SpawnNewWall ;
    }

    private void SpawnNewWall(int score)
    {
        
        Instantiate(wallPrefab,transform.position,Quaternion.identity);
        
    }
}

