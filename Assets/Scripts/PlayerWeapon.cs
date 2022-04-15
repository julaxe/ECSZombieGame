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

    
    public bool isShooting;

    [Header("Weapon Specs")] 
    [SerializeField] private GameObject _weaponRef;
    [SerializeField]private float _range;
    [SerializeField]private int _clipSize;
    
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

        _muzzleFlash.Play();
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
    
}
