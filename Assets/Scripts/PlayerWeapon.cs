using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private GameObject _muzzleLocation;
    [SerializeField] private GameObject _weaponRef;

    public bool isShooting;
    public UnityAction Reload;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var fire = Input.GetAxis("Fire1");
        isShooting = fire == 1.0f;
    }

    public void Shoot()
    {
        
    }
    
}
