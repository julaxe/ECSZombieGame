using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimation : MonoBehaviour
{
    private SeekPlayer _seekPlayer;
    private Animator _animator;

    private readonly int hashSpeedAnimation = Animator.StringToHash("speed");

    private void Awake()
    {
        _seekPlayer = GetComponent<SeekPlayer>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat(hashSpeedAnimation, _seekPlayer.Speed / _seekPlayer.MaxSpeed);
    }
}
