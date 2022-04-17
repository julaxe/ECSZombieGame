using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.VFX;

public class PlayerWeapon : MonoBehaviour
{
    [Header("Muzzle")]
    [SerializeField] private VisualEffect _muzzleFlash;
    [SerializeField] private GameObject _muzzleLocation;
    [SerializeField] private GameObject _bulletTrail;

    
    public bool isShooting;

    [Header("Weapon Specs")] 
    [SerializeField] private GameObject _weaponRef;
    [SerializeField]private float _range = 20.0f;
    [SerializeField]private int _clipSize = 30;
    [SerializeField] private float _fireRate = 1.0f;
    private int _currentAmmo;

    [Header("BloodEffect")] [SerializeField]
    private GameObject _bloofEffectRef;

    [Header("UI")] 
    [SerializeField] private GameObject _UIWeapon1;
    [SerializeField] private GameObject _UIWeapon2;
    [SerializeField] private GameObject _UIZombieCounter;

    private int _currentZombieCount = 0;
    
    void Start()
    {
        _currentAmmo = _clipSize;
    }

    // Update is called once per frame
    void Update()
    {
        var fire = Input.GetAxis("Fire1");
        isShooting = fire == 1.0f;
    }

    public void Shoot()
    {
        SpawnMuzzle();

        CheckCollisionWithZombie();

        _currentAmmo -= 1;
    }

    private void SpawnMuzzle()
    {
        _muzzleFlash.transform.rotation = _muzzleLocation.transform.rotation;
        _muzzleFlash.transform.position = _muzzleLocation.transform.position;
        _muzzleFlash.Play();
    }
    private void SpawnBulletTrail(Vector3? hitPoint = null)
    {
        var bulletTrail = Instantiate(_bulletTrail, _muzzleLocation.transform.position, Quaternion.identity);

        var lineR = bulletTrail.GetComponent<LineRenderer>();
        
        lineR.SetPosition(0, _muzzleLocation.transform.position);
        if (hitPoint == null)
        {
            var endPoint = transform.forward * _range;
            lineR.SetPosition(1, _muzzleLocation.transform.position + endPoint);
        }
        else
        {
            lineR.SetPosition(1, hitPoint.Value);
        }
        Destroy(bulletTrail, 1.0f);
    }

    private void CheckCollisionWithZombie()
    {
        Vector3 shootDirection = transform.forward;
        RaycastHit hit;
        if (Physics.Raycast(_muzzleLocation.transform.position, shootDirection, out hit, _range))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                hit.collider.GetComponent<ZombieAnimation>().DeathAnimation();
                SpawnBlood(hit);
                CountAZombie();
                
            }
            SpawnBulletTrail(hit.point);
            return;
        }

        SpawnBulletTrail();

    }

    private void CountAZombie()
    {
        _currentZombieCount += 1;
        _UIZombieCounter.GetComponent<Text>().text = _currentZombieCount.ToString();
    }
    

    private void SpawnBlood(RaycastHit hit)
    {
        var blood = Instantiate(_bloofEffectRef, hit.point, hit.transform.rotation);
        Destroy(blood, 5.0f);
    }

    public bool OutOfAmmo()
    {
        return _currentAmmo <= 0;
    }

    public void Reload()
    {
        _currentAmmo = _clipSize;
    }

    public int GetCurrentAmmo()
    {
        return _currentAmmo;
    }

    public float GetFireRate()
    {
        return _fireRate;
    }

    public void UpdateWeaponInfo(Weapon weapon, Weapon secondary)
    {
        _clipSize = weapon.weaponInfo.clipSize;
        _range = weapon.weaponInfo.range;
        _fireRate = weapon.weaponInfo.fireRate;
        _currentAmmo = weapon.currentAmmo;
        _muzzleFlash = weapon.weaponInfo.visualEffectRef;
        _bulletTrail = weapon.weaponInfo.bulletTrail;
        _weaponRef.GetComponent<SkinnedMeshRenderer>().material = weapon.weaponInfo.material;
        _UIWeapon1.GetComponent<RawImage>().texture = weapon.weaponInfo.panel;
        if (secondary)
        {
            _UIWeapon2.GetComponent<RawImage>().texture = secondary.weaponInfo.panel;
        }
        
    }
    
    
}
