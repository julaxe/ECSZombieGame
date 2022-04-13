using System;
using DotsNav.Data;
using DotsNav.PathFinding;
using DotsNav.PathFinding.Data;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[GenerateAuthoringComponent]
public struct MoveAgent : IComponentData
{
    public Entity target;
    public float speed;
}

// public partial class MoveAgentSystem : SystemBase
// {
//     protected override void OnUpdate()
//     {
//         float deltaTime = Time.DeltaTime;
//
//         Entities.ForEach((ref PathQueryComponent path, in MoveAgent agent) =>
//         {
//             ComponentDataFromEntity<Translation> allTranslations = GetComponentDataFromEntity<Translation>(true);
//             Translation targetPos = allTranslations[agent.target];
//             path.To = targetPos.Value;
//
//             if (path.State == PathQueryState.Pending) return;
//             path.State = PathQueryState.Pending;
//         }).ScheduleParallel();
//         
//         Entities.ForEach((Translation pos, in DirectionComponent direction, in MoveAgent agent) =>
//         {
//             if (direction.Value.Equals(float2.zero)) return;
//             float2 normalizedDirection = math.normalizesafe(direction.Value);
//             float2 newVelocity = normalizedDirection * agent.speed * deltaTime;
//             pos.Value += new float3(newVelocity.x, 0.0f, newVelocity.y);
//         }).ScheduleParallel();
//     }
// }
