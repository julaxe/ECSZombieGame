using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<WeaponSO> _possibleWeapons;
    [SerializeField] private GameObject _weaponPrefab;

    [Header("VisualEffectsMuzzle")] 
    [SerializeField] private List<VisualEffect> _muzzles;

    private List<GameObject> _weapons;
    private PlayerWeapon _playerWeapon;
    private int _currentWeapon = 0;


    private void Awake()
    {
        _playerWeapon = GetComponent<PlayerWeapon>();
        _weapons = new List<GameObject>();
    }

    private void Start()
    {
        for (int i = 0; i < _possibleWeapons.Count; i++)
        {
            var temp = Instantiate(_weaponPrefab);
            temp.GetComponent<Weapon>().weaponInfo = _possibleWeapons[i].weaponInfo;
            temp.GetComponent<Weapon>().weaponInfo.visualEffectRef = _muzzles[i];
            temp.GetComponent<Weapon>().currentAmmo = _possibleWeapons[i].weaponInfo.clipSize;
            _weapons.Add(temp);
        }

        UpdatePlayerWeaponInfo();
    }

    private void Update()
    {
        if (Input.GetButtonDown("SwapWeapons"))
        {
            SwapWeapons(_playerWeapon.GetCurrentAmmo());
        }
    }


    private void UpdatePlayerWeaponInfo()
    {
        _playerWeapon.UpdateWeaponInfo(_weapons[0].GetComponent<Weapon>(), null);
    }

    private void SwapWeapons(int currentAmmo)
    {
        _weapons[_currentWeapon].GetComponent<Weapon>().currentAmmo = currentAmmo;
        if (_currentWeapon == 0)
        {
            _currentWeapon = 1;
            _playerWeapon.UpdateWeaponInfo(_weapons[1].GetComponent<Weapon>(), _weapons[0].GetComponent<Weapon>());
        }
        else if (_currentWeapon == 1)
        {
            _currentWeapon = 0;
            _playerWeapon.UpdateWeaponInfo(_weapons[0].GetComponent<Weapon>(), _weapons[1].GetComponent<Weapon>());
        }
    }
    
    
}
