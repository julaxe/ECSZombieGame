using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Animator _animator;
    private PlayerWeapon _weapon;

    private readonly int hashVelXAnimation = Animator.StringToHash("velX");
    private readonly int hashVelYAnimation = Animator.StringToHash("velY");
    private readonly int hashShootingAnimation = Animator.StringToHash("Shooting");

    [SerializeField] private Vector3 cross;
    [SerializeField] private float dotprod;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _weapon = GetComponent<PlayerWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFacingDirection();
        _animator.SetBool(hashShootingAnimation, _weapon.isShooting);
    }

    private void UpdateFacingDirection()
    {
        var normalizedVel = _rigidbody.velocity.normalized;
        var forward = transform.forward;
        cross = Vector3.Cross(forward, normalizedVel); // right or left
        dotprod = Vector3.Dot(forward, normalizedVel); // forward or backwards
  
        _animator.SetFloat(hashVelXAnimation, cross.y);
        _animator.SetFloat(hashVelYAnimation, dotprod);
    }
    
}
