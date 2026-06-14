using Unity.Entities;
using Unity.Mathematics;

namespace Unity.Rendering
{
    [MaterialProperty("_Cull")]
    struct CullFloatOverride : IComponentData
    {
        public float Value;
    }
}
