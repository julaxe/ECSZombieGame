using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public float friction = 1.0f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        float aimX = Input.GetAxis("AimX");
        float aimY = Input.GetAxis("AimY");
        
        var newVelocity = math.normalizesafe(new float2(x, y)) * speed * Time.deltaTime;
        _rigidbody.velocity = new Vector3(newVelocity.x, 0.0f, newVelocity.y);

        if (aimX != 0.0f || aimY != 0.0f)
        {
            var newRot = Quaternion.LookRotation(new Vector3(aimX, 0.0f, aimY));
            transform.rotation = newRot;
        }

    }
}
