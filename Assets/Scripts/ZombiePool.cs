using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePool : MonoBehaviour
{
    private List<GameObject> _zombieList;

    private void Awake()
    {
        _zombieList = new List<GameObject>();
    }

    public void AddZombieToList(GameObject zombie)
    {
        _zombieList.Add(zombie);
        zombie.SetActive(false);
    }

    public GameObject GetZombie()
    {
        var zombie = _zombieList.Find(x => !x.activeInHierarchy);
        zombie.SetActive(true);
        return zombie;
    }
}
