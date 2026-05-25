using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS
{
    
    public struct CubeComponent : IComponentData
    {
        public float3 moveDirection;
        public float moveSpeed;
    }
}

