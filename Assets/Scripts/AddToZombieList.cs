using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToZombieList : MonoBehaviour
{
    [SerializeField]
    private ZombiePool _zombiePool;

    private void Start()
    {
        _zombiePool.AddZombieToList(gameObject);
    }
}

