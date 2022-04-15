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
        Debug.Log("shoot");

        SpawnMuzzle();

        SpawnBulletTrail();
        // //spawn muzzle
        // Vector3 shootDirection = transform.forward;
        // // GameObject muzzle = Instantiate(_muzzleRef, _muzzleLocation.transform.position,
        // //     Quaternion.FromToRotation(Vector3.up, shootDirection));
        // // Destroy(muzzle, 1.0f);
        // RaycastHit hit;
        // if (Physics.Raycast(_muzzleLocation.transform.position, shootDirection, out hit, _range))
        // {
        //     
        // }
    }

    private void SpawnMuzzle()
    {
        _muzzleFlash.transform.rotation = _muzzleLocation.transform.rotation;
        _muzzleFlash.transform.position = _muzzleLocation.transform.position;
        _muzzleFlash.Play();
    }
    private void SpawnBulletTrail(Vector3? hitPoint = null)
    {
        if (hitPoint == null)
        {
            var bulletTrail = Instantiate(_bulletTrail, _muzzleLocation.transform.position, Quaternion.identity);

            var lineR = bulletTrail.GetComponent<LineRenderer>();

            var endPoint = transform.forward * _range;
            lineR.SetPosition(0, _muzzleLocation.transform.position);
            lineR.SetPosition(1, _muzzleLocation.transform.position + endPoint);

            Destroy(bulletTrail, 1.0f);
        }
    }
    
}
