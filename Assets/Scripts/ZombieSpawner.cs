using System;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Random = Unity.Mathematics.Random;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _playerRef;
    [SerializeField] private GameObject _UIWaveNumber;
    private ZombiePool _zombiePool;

    private Random _random;

    private List<GameObject> _currentWave;

    private int _currentWaveNumber = 0;
    private void Awake()
    {
        _zombiePool = GetComponent<ZombiePool>();
        _currentWave = new List<GameObject>();
        _random = new Random(56);
    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     float distance = 25f;
        //     SpawnAZombie(distance);
        // }

        if (CurrentWaveCleared())
        {
            _currentWave.Clear();
            SpawnNextWave();
        }
    }

    private bool CurrentWaveCleared()
    {
        return !_currentWave.Exists(x => x.activeInHierarchy);
    }

    private void SpawnAZombie(float distance)
    {
        var zombie = _zombiePool.GetZombie();
        if (zombie)
        {
            var randomPositionX = _random.NextFloat(-1.0f, 1.0f);
            var randomPositionY = _random.NextFloat(-1.0f, 1.0f);
            float2 randomPos = new float2(randomPositionX, randomPositionY);
            float2 normalizedRandomPos = math.normalizesafe(randomPos);
            Vector3 newPos = new Vector3(normalizedRandomPos.x, 0.0f, normalizedRandomPos.y);
                
            zombie.transform.position = _playerRef.transform.position + (newPos * distance);
            zombie.transform.position = new Vector3(zombie.transform.position.x, 0.0f, zombie.transform.position.z);
            _currentWave.Add(zombie);
        }
        else
        {
            //not zombies available
        }
    }

    private void SpawnNextWave()
    {
        _currentWaveNumber += 1;

        int numberOfZombieToSpawn = _currentWaveNumber * 20;
        for (int i = 0; i < numberOfZombieToSpawn; i++)
        {
            float distance = 25f;
            SpawnAZombie(distance);
        }

        UpdateUIWaveNumber();
    }

    private void UpdateUIWaveNumber()
    {
        _UIWaveNumber.GetComponent<Text>().text = _currentWaveNumber.ToString();
    }
    
    
}
