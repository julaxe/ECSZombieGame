using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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

    [Header("BloodEffect")] [SerializeField]
    private GameObject _bloofEffectRef;
    
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
        SpawnMuzzle();

        CheckCollisionWithZombie();
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
            }
            SpawnBulletTrail(hit.point);
            return;
        }

        SpawnBulletTrail();

    }

    private void SpawnBlood(RaycastHit hit)
    {
        var blood = Instantiate(_bloofEffectRef, hit.point, hit.transform.rotation);
        Destroy(blood, 5.0f);
    }
    
    
    
}
