using System;
using DotsNav.Hybrid;
using DotsNav.PathFinding;
using DotsNav.PathFinding.Hybrid;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class SeekPlayer : MonoBehaviour
{
    public GameObject PlayerRef;
    public float Speed = 1.0f;
    public float MaxSpeed = 1.0f;
    public float AttackingDistance = 1.5f;

    private DotsNavPathFindingAgent _agent;
    private DotsNavAgent _agentPlane;
    private void Awake()
    {
        _agent = GetComponent<DotsNavPathFindingAgent>();
        _agentPlane = GetComponent<DotsNavAgent>();
        PlayerRef = FindObjectOfType<PlayerMovement>().gameObject;
        
        _agentPlane.Plane = FindObjectOfType<DotsNavPlane>();
       
    }

    private void Update()
    {
        GoTowardsPlayer();
    }

    private void GoTowardsPlayer()
    {
        //if (_agent.State == PathQueryState.Pending) return;
        if (_agent.State != PathQueryState.PathFound && _agent.State != PathQueryState.StartInvalid)
        {
            _agent.FindPath(PlayerRef.transform.position);
            return;
        }

        if (math.distance(x: transform.position, PlayerRef.transform.position) <= AttackingDistance)
        {
            Speed = 0.0f;
        }
        else
        {
            Speed = MaxSpeed;
            //attack animation ?
        }
        _agent.FindPath(PlayerRef.transform.position);
        float3 agentDirection = _agent.Direction;
        if (agentDirection.Equals(float3.zero)) return;
        agentDirection.y = 0.0f;
        float3 normalizedDirection = math.normalizesafe(agentDirection);
        float3 newVelocity = normalizedDirection * Speed * Time.deltaTime;
        transform.position += new Vector3(newVelocity.x, 0.0f, newVelocity.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(agentDirection),
            Time.deltaTime * Speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Destroy(this.gameObject);
    }
}



