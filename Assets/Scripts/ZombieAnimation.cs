using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ZombieAnimation : MonoBehaviour
{
    private SeekPlayer _seekPlayer;
    private Animator _animator;
    private BoxCollider _boxCollider;


    private readonly int hashSpeedAnimation = Animator.StringToHash("speed");
    private readonly int hashDeathAnimation = Animator.StringToHash("death");

    private void Awake()
    {
        _seekPlayer = GetComponent<SeekPlayer>();
        _animator = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat(hashSpeedAnimation, _seekPlayer.Speed / _seekPlayer.MaxSpeed);
    }

    public void DeathAnimation()
    {
        _animator.applyRootMotion = true;
        _boxCollider.enabled = false;
        _seekPlayer.enabled = false;
        _animator.SetTrigger(hashDeathAnimation);
        StartCoroutine(InactiveInSeconds(5.0f));
    }

    IEnumerator InactiveInSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        _animator.applyRootMotion = false;
        _boxCollider.enabled = true;
        _seekPlayer.enabled = true;
        _animator.Play("0-idle_agressive");
        gameObject.SetActive(false);
    }
    
}
