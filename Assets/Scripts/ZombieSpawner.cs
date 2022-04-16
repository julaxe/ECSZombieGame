using System;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _playerRef;
    private ZombiePool _zombiePool;

    private Random _random;
    private void Awake()
    {
        _zombiePool = GetComponent<ZombiePool>();
        _random = new Random(56);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var zombie = _zombiePool.GetZombie();
            var randomPositionX = _random.NextFloat(-1.0f, 1.0f);
            var randomPositionY = _random.NextFloat(-1.0f, 1.0f);
            float2 randomPos = new float2(randomPositionX, randomPositionY);
            float2 normalizedRandomPos = math.normalizesafe(randomPos);
            Vector3 newPos = new Vector3(normalizedRandomPos.x, 0.0f, normalizedRandomPos.y);
            
            zombie.transform.position = _playerRef.transform.position + (newPos * 15f);
            zombie.transform.position = new Vector3(zombie.transform.position.x, 0.0f, zombie.transform.position.z);
        }
    }
}
